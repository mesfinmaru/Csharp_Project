using CRM_API.Models;
using CRMdataLayer;
using CRMdataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CustomersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerVM>>> GetCustomers(string search = null)
        {
            try
            {
                var query = _context.Customers.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(c =>
                        c.FullName.Contains(search) ||
                        c.Email.Contains(search) ||
                        c.Phone.Contains(search) ||
                        c.LicenseNumber.Contains(search) ||
                        c.City.Contains(search));
                }

                var customers = await query
                    .OrderByDescending(c => c.CreatedAt)
                    .Select(c => new CustomerVM
                    {
                        Id = c.Id,
                        FullName = c.FullName,
                        Email = c.Email,
                        Phone = c.Phone,
                        Address = c.Address,
                        City = c.City,
                        Country = c.Country,
                        LicenseNumber = c.LicenseNumber,
                        LicenseType = c.LicenseType,
                        LicenseExpiryDate = c.LicenseExpiryDate,
                        CreatedAt = c.CreatedAt,
                        IsActive = c.IsActive
                    })
                    .ToListAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVM>> GetCustomer(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                var customerVM = new CustomerVM
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    City = customer.City,
                    Country = customer.Country,
                    LicenseNumber = customer.LicenseNumber,
                    LicenseType = customer.LicenseType,
                    LicenseExpiryDate = customer.LicenseExpiryDate,
                    CreatedAt = customer.CreatedAt,
                    IsActive = customer.IsActive
                };

                return Ok(customerVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerVM>> CreateCustomer(CustomerVM customerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if phone already exists
                var existingPhone = await _context.Customers
                    .AnyAsync(c => c.Phone == customerVM.Phone);

                if (existingPhone)
                {
                    return BadRequest("Phone number already exists");
                }

                // Check if email already exists (if provided)
                if (!string.IsNullOrEmpty(customerVM.Email))
                {
                    var existingEmail = await _context.Customers
                        .AnyAsync(c => c.Email == customerVM.Email);

                    if (existingEmail)
                    {
                        return BadRequest("Email already exists");
                    }
                }

                var customer = new Customers
                {
                    FullName = customerVM.FullName,
                    Email = customerVM.Email,
                    Phone = customerVM.Phone,
                    Address = customerVM.Address,
                    City = customerVM.City,
                    Country = customerVM.Country,
                    LicenseNumber = customerVM.LicenseNumber,
                    LicenseType = customerVM.LicenseType,
                    LicenseExpiryDate = customerVM.LicenseExpiryDate,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                customerVM.Id = customer.Id;
                customerVM.CreatedAt = customer.CreatedAt;
                customerVM.IsActive = customer.IsActive;

                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customerVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerVM customerVM)
        {
            try
            {
                if (id != customerVM.Id)
                {
                    return BadRequest("ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                // Check if phone already exists for another customer
                var existingPhone = await _context.Customers
                    .AnyAsync(c => c.Phone == customerVM.Phone && c.Id != id);

                if (existingPhone)
                {
                    return BadRequest("Phone number already exists for another customer");
                }

                // Check if email already exists for another customer (if provided)
                if (!string.IsNullOrEmpty(customerVM.Email))
                {
                    var existingEmail = await _context.Customers
                        .AnyAsync(c => c.Email == customerVM.Email && c.Id != id);

                    if (existingEmail)
                    {
                        return BadRequest("Email already exists for another customer");
                    }
                }

                customer.FullName = customerVM.FullName;
                customer.Email = customerVM.Email;
                customer.Phone = customerVM.Phone;
                customer.Address = customerVM.Address;
                customer.City = customerVM.City;
                customer.Country = customerVM.Country;
                customer.LicenseNumber = customerVM.LicenseNumber;
                customer.LicenseType = customerVM.LicenseType;
                customer.LicenseExpiryDate = customerVM.LicenseExpiryDate;
                customer.IsActive = customerVM.IsActive;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                // Check if customer has any rentals
                var hasRentals = await _context.Rentals.AnyAsync(r => r.CustomerId == id);
                if (hasRentals)
                {
                    return BadRequest("Cannot delete customer with existing rentals. Deactivate instead.");
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PATCH: api/Customers/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateCustomerStatus(int id, [FromBody] bool isActive)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found");
                }

                customer.IsActive = isActive;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}