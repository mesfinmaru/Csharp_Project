using CRM_API.Models;
using CRMdataLayer;
using CRMdataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public RentalsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalVM>>> Get(string? search = null)
        {
            try
            {
                var query = _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(r =>
                        (r.Customer != null && r.Customer.FullName != null && r.Customer.FullName.Contains(search)) ||
                        (r.Vehicle != null && r.Vehicle.PlateNumber != null && r.Vehicle.PlateNumber.Contains(search)) ||
                        (r.Status != null && r.Status.Contains(search)) ||
                        (r.TransactionId != null && r.TransactionId.Contains(search))
                    );
                }

                var rentals = await query.OrderByDescending(r => r.CreatedAt).ToListAsync();

                var rentalVMs = rentals.Select(r => new RentalVM
                {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    CustomerName = r.Customer?.FullName ?? "Unknown",
                    CustomerPhone = r.Customer?.Phone ?? "",
                    CustomerLicense = r.Customer?.LicenseNumber ?? "",
                    VehicleId = r.VehicleId,
                    VehiclePlateNumber = r.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = r.Vehicle?.Make ?? "",
                    VehicleModel = r.Vehicle?.Model ?? "",
                    VehicleColor = r.Vehicle?.Color ?? "",
                    VehicleType = r.Vehicle?.VehicleType ?? "",
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    ActualReturnDate = r.ActualReturnDate,
                    DailyRate = r.DailyRate,
                    RentalDays = r.RentalDays,
                    SubTotal = r.SubTotal,
                    LateFee = r.LateFee,
                    DamageFee = r.DamageFee,
                    Discount = r.Discount,
                    TotalAmount = r.TotalAmount,
                    AmountPaid = r.AmountPaid,
                    BalanceDue = r.BalanceDue,
                    IsPaid = r.IsPaid,
                
                    TransactionId = r.TransactionId,
                    PaymentNotes = r.PaymentNotes,
                    Status = r.Status,
                    IsActive = r.IsActive,
                    Notes = r.Notes,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt
                }).ToList();

                return Ok(rentalVMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving rentals: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalVM>> Get(int id)
        {
            try
            {
                var rental = await _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (rental == null)
                {
                    return NotFound(new { message = $"Rental with ID {id} not found" });
                }

                var rentalVM = new RentalVM
                {
                    Id = rental.Id,
                    CustomerId = rental.CustomerId,
                    CustomerName = rental.Customer?.FullName ?? "Unknown",
                    CustomerPhone = rental.Customer?.Phone ?? "",
                    CustomerLicense = rental.Customer?.LicenseNumber ?? "",
                    VehicleId = rental.VehicleId,
                    VehiclePlateNumber = rental.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = rental.Vehicle?.Make ?? "",
                    VehicleModel = rental.Vehicle?.Model ?? "",
                    VehicleColor = rental.Vehicle?.Color ?? "",
                    VehicleType = rental.Vehicle?.VehicleType ?? "",
                    StartDate = rental.StartDate,
                    EndDate = rental.EndDate,
                    ActualReturnDate = rental.ActualReturnDate,
                    DailyRate = rental.DailyRate,
                    RentalDays = rental.RentalDays,
                    SubTotal = rental.SubTotal,
                    LateFee = rental.LateFee,
                    DamageFee = rental.DamageFee,
                    Discount = rental.Discount,
                    TotalAmount = rental.TotalAmount,
                    AmountPaid = rental.AmountPaid,
                    BalanceDue = rental.BalanceDue,
                    IsPaid = rental.IsPaid,
           
                    TransactionId = rental.TransactionId,
                    PaymentNotes = rental.PaymentNotes,
                    Status = rental.Status,
                    IsActive = rental.IsActive,
                    Notes = rental.Notes,
                    CreatedAt = rental.CreatedAt,
                    UpdatedAt = rental.UpdatedAt
                };

                return Ok(rentalVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving rental: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<RentalVM>> Post([FromBody] RentalVM rentalVM)
        {
            try
            {
                if (rentalVM == null)
                {
                    return BadRequest(new { message = "Rental data is required" });
                }

                // Validate customer exists
                var customer = await _context.Customers.FindAsync(rentalVM.CustomerId);
                if (customer == null)
                {
                    return BadRequest(new { message = "Customer not found" });
                }

                // Validate vehicle exists and is available
                var vehicle = await _context.Vehicles.FindAsync(rentalVM.VehicleId);
                if (vehicle == null)
                {
                    return BadRequest(new { message = "Vehicle not found" });
                }

                if (!vehicle.IsAvailable || !vehicle.IsActive)
                {
                    return BadRequest(new { message = "Vehicle is not available for rental" });
                }

                // Calculate rental details
                int rentalDays = (rentalVM.EndDate - rentalVM.StartDate).Days;
                if (rentalDays < 1) rentalDays = 1;

                decimal subTotal = rentalVM.DailyRate * rentalDays;
                decimal totalAmount = subTotal - (rentalVM.Discount ?? 0);
                decimal balanceDue = totalAmount - rentalVM.AmountPaid;
                bool isPaid = rentalVM.AmountPaid >= totalAmount;

                // Create rental entity
                var rental = new Rentals
                {
                    CustomerId = rentalVM.CustomerId,
                    VehicleId = rentalVM.VehicleId,
                    StartDate = rentalVM.StartDate,
                    EndDate = rentalVM.EndDate,
                    DailyRate = rentalVM.DailyRate,
                    RentalDays = rentalDays,
                    SubTotal = subTotal,
                    Discount = rentalVM.Discount,
                    TotalAmount = totalAmount,
                    AmountPaid = rentalVM.AmountPaid,
                    BalanceDue = balanceDue,
                    IsPaid = isPaid,
                  
                    TransactionId = rentalVM.TransactionId,
                    PaymentNotes = rentalVM.PaymentNotes,
                    Status = "Active",
                    IsActive = true,
                    Notes = rentalVM.Notes,
                    CreatedAt = DateTime.UtcNow
                };

                // Update vehicle status
                vehicle.IsAvailable = false;
                vehicle.Status = "Rented";
                vehicle.UpdatedAt = DateTime.UtcNow;

                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                // Return created rental
                rentalVM.Id = rental.Id;
                rentalVM.RentalDays = rental.RentalDays;
                rentalVM.SubTotal = rental.SubTotal;
                rentalVM.TotalAmount = rental.TotalAmount;
                rentalVM.BalanceDue = rental.BalanceDue;
                rentalVM.IsPaid = rental.IsPaid;
                rentalVM.Status = rental.Status;
                rentalVM.IsActive = rental.IsActive;
                rentalVM.CreatedAt = rental.CreatedAt;

                return CreatedAtAction(nameof(Get), new { id = rental.Id }, rentalVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error creating rental: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RentalVM rentalVM)
        {
            try
            {
                var rental = await _context.Rentals.FindAsync(id);
                if (rental == null)
                {
                    return NotFound(new { message = $"Rental with ID {id} not found" });
                }

                // Only update allowed fields (not customer/vehicle)
                rental.StartDate = rentalVM.StartDate;
                rental.EndDate = rentalVM.EndDate;
                rental.DailyRate = rentalVM.DailyRate;

                // Recalculate
                int rentalDays = (rental.EndDate - rental.StartDate).Days;
                if (rentalDays < 1) rentalDays = 1;

                rental.RentalDays = rentalDays;
                rental.SubTotal = rental.DailyRate * rentalDays;
                rental.Discount = rentalVM.Discount;
                rental.TotalAmount = rental.SubTotal - (rental.Discount ?? 0);
                rental.AmountPaid = rentalVM.AmountPaid;
                rental.BalanceDue = rental.TotalAmount - rentalVM.AmountPaid;
                rental.IsPaid = rentalVM.AmountPaid >= rental.TotalAmount;
              
                rental.TransactionId = rentalVM.TransactionId;
                rental.PaymentNotes = rentalVM.PaymentNotes;
                rental.Status = rentalVM.Status;
                rental.IsActive = rentalVM.IsActive;
                rental.Notes = rentalVM.Notes;
                rental.UpdatedAt = DateTime.UtcNow;

                // Update vehicle status if rental is cancelled
                if (rental.Status == "Cancelled" && rental.VehicleId > 0)
                {
                    var vehicle = await _context.Vehicles.FindAsync(rental.VehicleId);
                    if (vehicle != null)
                    {
                        vehicle.IsAvailable = true;
                        vehicle.Status = "Available";
                        vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(rentalVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating rental: {ex.Message}" });
            }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnVehicle(int id, [FromBody] ReturnRequest request)
        {
            try
            {
                var rental = await _context.Rentals
                    .Include(r => r.Vehicle)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (rental == null)
                {
                    return NotFound(new { message = $"Rental with ID {id} not found" });
                }

                if (rental.Status == "Completed")
                {
                    return BadRequest(new { message = "Vehicle already returned" });
                }

                // Update rental with return details
                rental.ActualReturnDate = request.ActualReturnDate;
                rental.LateFee = request.LateFee;
                rental.DamageFee = request.DamageFee;
                rental.Notes = rental.Notes + "\n" + request.Notes;

                // Recalculate total with fees
                decimal newTotal = rental.TotalAmount + (request.LateFee ?? 0) + (request.DamageFee ?? 0);
                rental.TotalAmount = newTotal;
                rental.BalanceDue = newTotal - rental.AmountPaid;
                rental.IsPaid = rental.AmountPaid >= newTotal;
                rental.Status = "Completed";
                rental.UpdatedAt = DateTime.UtcNow;

                // Update vehicle status
                if (rental.Vehicle != null)
                {
                    rental.Vehicle.IsAvailable = true;
                    rental.Vehicle.Status = "Available";
                    rental.Vehicle.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Vehicle returned successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error returning vehicle: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rental = await _context.Rentals.FindAsync(id);
                if (rental == null)
                {
                    return NotFound(new { message = $"Rental with ID {id} not found" });
                }

                // If rental is active, free up the vehicle
                if (rental.Status == "Active" && rental.VehicleId > 0)
                {
                    var vehicle = await _context.Vehicles.FindAsync(rental.VehicleId);
                    if (vehicle != null)
                    {
                        vehicle.IsAvailable = true;
                        vehicle.Status = "Available";
                        vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                }

                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Rental deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting rental: {ex.Message}" });
            }
        }

        private async Task<bool> RentalExists(int id)
        {
            return await _context.Rentals.AnyAsync(e => e.Id == id);
        }
    }

    public class ReturnRequest
    {
        public DateTime ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public string? Notes { get; set; }
    }
}