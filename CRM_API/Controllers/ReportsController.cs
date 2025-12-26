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
    public class ReportsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ReportsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<CustomerReportVM>>> GetCustomerReport(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string status = "All")
        {
            try
            {
                var query = _context.Customers.AsQueryable();

                // Apply date filter
                if (fromDate.HasValue)
                {
                    query = query.Where(c => c.CreatedAt >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    query = query.Where(c => c.CreatedAt <= toDate.Value);
                }

                // Apply status filter
                if (status != "All")
                {
                    bool isActive = status == "Active";
                    query = query.Where(c => c.IsActive == isActive);
                }

                var customers = await query.ToListAsync();
                var result = new List<CustomerReportVM>();

                foreach (var customer in customers)
                {
                    // Get customer's rentals
                    var customerRentals = await _context.Rentals
                        .Where(r => r.CustomerId == customer.Id)
                        .ToListAsync();

                    var reportItem = new CustomerReportVM
                    {
                        CustomerId = customer.Id,
                        FullName = customer.FullName,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        RegistrationDate = customer.CreatedAt,
                        TotalRentals = customerRentals.Count,
                        TotalSpent = customerRentals.Sum(r => r.TotalAmount),
                        IsActive = customer.IsActive
                    };

                    result.Add(reportItem);
                }

                return Ok(result.OrderByDescending(c => c.TotalSpent));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating customer report: {ex.Message}");
            }
        }

        [HttpGet("rentals")]
        public async Task<ActionResult<IEnumerable<RentalReportVM>>> GetRentalReport(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string status = "All",
            [FromQuery] string vehicleType = "All")
        {
            try
            {
                var query = _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .AsQueryable();

                // Apply date filter
                if (fromDate.HasValue)
                {
                    query = query.Where(r => r.StartDate >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    query = query.Where(r => r.StartDate <= toDate.Value);
                }

                // Apply status filter
                if (status != "All")
                {
                    query = query.Where(r => r.Status == status);
                }

                var rentals = await query.ToListAsync();
                var result = new List<RentalReportVM>();

                foreach (var rental in rentals)
                {
                    // Apply vehicle type filter
                    if (vehicleType != "All" && rental.Vehicle?.VehicleType != vehicleType)
                        continue;

                    var rentalDays = (rental.EndDate - rental.StartDate).Days;
                    if (rentalDays < 1) rentalDays = 1;

                    var reportItem = new RentalReportVM
                    {
                        RentalId = rental.Id,
                        CustomerName = rental.Customer?.FullName ?? "Unknown",
                        VehicleInfo = $"{rental.Vehicle?.Make} {rental.Vehicle?.Model} ({rental.Vehicle?.PlateNumber})",
                        VehicleType = rental.Vehicle?.VehicleType ?? "Unknown",
                        StartDate = rental.StartDate,
                        EndDate = rental.EndDate,
                        ActualReturnDate = rental.ActualReturnDate,
                        TotalAmount = rental.TotalAmount,
                        Status = rental.Status,
                        RentalDays = rentalDays,
                        IsPaid = rental.IsPaid,
                        PaymentMethod = rental.PaymentNotes,
                        PaymentStatus = rental.IsPaid ? "Paid" : "Pending"
                    };

                    result.Add(reportItem);
                }

                return Ok(result.OrderByDescending(r => r.StartDate));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating rental report: {ex.Message}");
            }
        }

        [HttpGet("vehicles")]
        public async Task<ActionResult<IEnumerable<VehicleReportVM>>> GetVehicleReport(
            [FromQuery] string vehicleType = "All",
            [FromQuery] string status = "All")
        {
            try
            {
                var query = _context.Vehicles.AsQueryable();

                // Apply vehicle type filter
                if (vehicleType != "All")
                {
                    query = query.Where(v => v.VehicleType == vehicleType);
                }

                // Apply status filter
                if (status != "All")
                {
                    if (status == "Active") query = query.Where(v => v.IsActive);
                    else if (status == "Inactive") query = query.Where(v => !v.IsActive);
                    else if (status == "Available") query = query.Where(v => v.IsAvailable && v.IsActive);
                    else if (status == "Rented") query = query.Where(v => !v.IsAvailable && v.IsActive);
                }

                var vehicles = await query.ToListAsync();
                var result = new List<VehicleReportVM>();

                foreach (var vehicle in vehicles)
                {
                    // Get vehicle rentals
                    var vehicleRentals = await _context.Rentals
                        .Where(r => r.VehicleId == vehicle.Id)
                        .ToListAsync();

                    var reportItem = new VehicleReportVM
                    {
                        VehicleId = vehicle.Id,
                        PlateNumber = vehicle.PlateNumber,
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        VehicleType = vehicle.VehicleType,
                        Year = vehicle.Year,
                        Color = vehicle.Color,
                        DailyRate = vehicle.DailyRate,
                        IsAvailable = vehicle.IsAvailable,
                        IsActive = vehicle.IsActive,
                        TimesRented = vehicleRentals.Count,
                        TotalRevenue = vehicleRentals.Sum(r => r.TotalAmount),
                        Status = CalculateVehicleStatus(vehicle.IsActive, vehicle.IsAvailable)
                    };

                    result.Add(reportItem);
                }

                return Ok(result.OrderByDescending(v => v.TotalRevenue));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating vehicle report: {ex.Message}");
            }
        }

        [HttpGet("financial")]
        public async Task<ActionResult<IEnumerable<FinancialReportVM>>> GetFinancialReport(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var query = _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .Where(r => r.IsPaid) // Only paid rentals
                    .AsQueryable();

                // Apply date filter
                if (fromDate.HasValue)
                {
                    query = query.Where(r => r.StartDate >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    query = query.Where(r => r.StartDate <= toDate.Value);
                }

                var rentals = await query.ToListAsync();
                var result = new List<FinancialReportVM>();

                foreach (var rental in rentals)
                {
                    var reportItem = new FinancialReportVM
                    {
                        RentalId = rental.Id,
                        RentalDate = rental.StartDate,
                        CustomerName = rental.Customer?.FullName ?? "Unknown",
                        VehicleInfo = $"{rental.Vehicle?.Make} {rental.Vehicle?.Model}",
                        Revenue = rental.TotalAmount,
                        PaymentMethod = rental.PaymentNotes,
                        IsPaid = rental.IsPaid,
                        TransactionId = rental.TransactionId
                    };

                    result.Add(reportItem);
                }

                return Ok(result.OrderBy(r => r.RentalDate));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating financial report: {ex.Message}");
            }
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<OverdueReportVM>>> GetOverdueReport()
        {
            try
            {
                var today = DateTime.Today;

                var overdueRentals = await _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .Where(r => r.Status == "Active" &&
                               r.EndDate < today &&
                               r.ActualReturnDate == null)
                    .ToListAsync();

                var result = new List<OverdueReportVM>();

                foreach (var rental in overdueRentals)
                {
                    int daysOverdue = (today - rental.EndDate).Days;

                    var reportItem = new OverdueReportVM
                    {
                        RentalId = rental.Id,
                        CustomerName = rental.Customer?.FullName ?? "Unknown",
                        Phone = rental.Customer?.Phone ?? "N/A",
                        Email = rental.Customer?.Email ?? "N/A",
                        VehicleInfo = $"{rental.Vehicle?.Make} {rental.Vehicle?.Model} ({rental.Vehicle?.PlateNumber})",
                        StartDate = rental.StartDate,
                        EndDate = rental.EndDate,
                        TotalAmount = rental.TotalAmount,
                        DaysOverdue = daysOverdue,
                        LateFee = rental.LateFee
                    };

                    result.Add(reportItem);
                }

                return Ok(result.OrderByDescending(r => r.DaysOverdue));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating overdue report: {ex.Message}");
            }
        }

        [HttpGet("summary")]
        public async Task<ActionResult<ReportSummaryVM>> GetReportSummary(
            [FromQuery] string reportType,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var summary = new ReportSummaryVM
                {
                    ReportType = reportType,
                    GeneratedDate = DateTime.UtcNow
                };

                // Get general statistics
                summary.TotalCustomers = await _context.Customers.CountAsync();
                summary.TotalVehicles = await _context.Vehicles.CountAsync();

                // Get rental statistics
                var rentalsQuery = _context.Rentals.AsQueryable();

                if (fromDate.HasValue)
                {
                    rentalsQuery = rentalsQuery.Where(r => r.StartDate >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    rentalsQuery = rentalsQuery.Where(r => r.StartDate <= toDate.Value);
                }

                var rentals = await rentalsQuery.ToListAsync();
                summary.TotalRevenue = rentals.Sum(r => r.TotalAmount);
                summary.ActiveRentals = rentals.Count(r => r.Status == "Active");
                summary.OverdueRentals = rentals.Count(r => r.Status == "Active" && r.EndDate < DateTime.Today);
                summary.TotalRecords = rentals.Count;

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating report summary: {ex.Message}");
            }
        }

        private string CalculateVehicleStatus(bool isActive, bool isAvailable)
        {
            if (!isActive) return "Inactive";
            if (!isAvailable) return "Rented";
            return "Available";
        }
    }
}