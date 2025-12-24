using CRM_API.Models;
using CRMdataLayer;
using CRMdataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ReportsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("rentals")]
        public async Task<ActionResult<RentalReportVM>> GetRentalReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] string? status = null)
        {
            try
            {
                var query = _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .AsQueryable();

                // Apply date filters
                if (startDate.HasValue)
                {
                    query = query.Where(r => r.StartDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(r => r.StartDate <= endDate.Value);
                }

                // Apply status filter
                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(r => r.Status == status);
                }

                var rentals = await query.OrderByDescending(r => r.StartDate).ToListAsync();
                var rentalVMs = rentals.Select(r => MapToRentalVM(r)).ToList();

                var report = new RentalReportVM
                {
                    ReportDate = DateTime.UtcNow,
                    ReportType = "Rental Report",
                    Rentals = rentalVMs,
                    TotalRevenue = rentalVMs.Sum(r => r.TotalAmount),
                    TotalRentals = rentalVMs.Count,
                    ActiveRentals = rentalVMs.Count(r => r.Status == "Active"),
                    CompletedRentals = rentalVMs.Count(r => r.Status == "Completed"),
                    OverdueRentals = rentalVMs.Count(r => r.IsOverdue)
                };

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error generating rental report: {ex.Message}" });
            }
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult<MaintenanceReportVM>> GetMaintenanceReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] string? status = null)
        {
            try
            {
                var query = _context.Maintenances
                    .Include(m => m.Vehicle)
                    .AsQueryable();

                if (startDate.HasValue)
                {
                    query = query.Where(m => m.MaintenanceDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(m => m.MaintenanceDate <= endDate.Value);
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(m => m.Status == status);
                }

                var maintenances = await query.OrderByDescending(m => m.MaintenanceDate).ToListAsync();
                var maintenanceVMs = maintenances.Select(m => MapToMaintenanceVM(m)).ToList();

                var report = new MaintenanceReportVM
                {
                    ReportDate = DateTime.UtcNow,
                    ReportType = "Maintenance Report",
                    Maintenances = maintenanceVMs,
                    TotalCost = maintenanceVMs.Sum(m => m.Cost),
                    TotalMaintenances = maintenanceVMs.Count,
                    ScheduledCount = maintenanceVMs.Count(m => m.Status == "Scheduled"),
                    InProgressCount = maintenanceVMs.Count(m => m.Status == "In Progress"),
                    CompletedCount = maintenanceVMs.Count(m => m.Status == "Completed"),
                    OverdueCount = maintenanceVMs.Count(m => m.IsOverdue)
                };

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error generating maintenance report: {ex.Message}" });
            }
        }

        [HttpGet("vehicles")]
        public async Task<ActionResult<VehicleReportVM>> GetVehicleReport()
        {
            try
            {
                var vehicles = await _context.Vehicles.ToListAsync();
                var vehicleVMs = vehicles.Select(v => MapToVehicleVM(v)).ToList();

                var report = new VehicleReportVM
                {
                    ReportDate = DateTime.UtcNow,
                    ReportType = "Vehicle Inventory Report",
                    Vehicles = vehicleVMs,
                    TotalVehicles = vehicleVMs.Count,
                    AvailableVehicles = vehicleVMs.Count(v => v.Status == "Available"),
                    RentedVehicles = vehicleVMs.Count(v => v.Status == "Rented"),
                    InMaintenanceVehicles = vehicleVMs.Count(v => v.Status == "In Maintenance"),
  
                };

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error generating vehicle report: {ex.Message}" });
            }
        }

        [HttpGet("financial")]
        public async Task<ActionResult<FinancialReportVM>> GetFinancialReport(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                // Get rentals in date range
                var rentals = await _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .Where(r => r.StartDate >= startDate && r.StartDate <= endDate)
                    .ToListAsync();

                var rentalVMs = rentals.Select(r => MapToRentalVM(r)).ToList();

                // Get maintenances in date range
                var maintenances = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .Where(m => m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate)
                    .ToListAsync();

                var maintenanceVMs = maintenances.Select(m => MapToMaintenanceVM(m)).ToList();

                var report = new FinancialReportVM
                {
                    ReportDate = DateTime.UtcNow,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalRevenue = rentalVMs.Sum(r => r.TotalAmount),
                    TotalMaintenanceCost = maintenanceVMs.Sum(m => m.Cost),
                    NetProfit = rentalVMs.Sum(r => r.TotalAmount) - maintenanceVMs.Sum(m => m.Cost),
                    Rentals = rentalVMs,
                    Maintenances = maintenanceVMs
                };

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error generating financial report: {ex.Message}" });
            }
        }

        // Helper mapping methods
        private RentalVM MapToRentalVM(Rentals rental)
        {
            return new RentalVM
            {
                Id = rental.Id,
                CustomerId = rental.CustomerId,
                CustomerName = rental.Customer?.FullName ?? "Unknown",
                VehicleId = rental.VehicleId,
                VehiclePlateNumber = rental.Vehicle?.PlateNumber ?? "Unknown",
                VehicleMake = rental.Vehicle?.Make ?? "",
                VehicleModel = rental.Vehicle?.Model ?? "",
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
                Status = rental.Status,
                CreatedAt = rental.CreatedAt
            };
        }

        private MaintenanceVM MapToMaintenanceVM(Maintenance maintenance)
        {
            return new MaintenanceVM
            {
                Id = maintenance.Id,
                VehicleId = maintenance.VehicleId,
                VehiclePlateNumber = maintenance.Vehicle?.PlateNumber ?? "Unknown",
                VehicleMake = maintenance.Vehicle?.Make ?? "",
                VehicleModel = maintenance.Vehicle?.Model ?? "",
                CurrentMileage = maintenance.CurrentMileage,
                MaintenanceDate = maintenance.MaintenanceDate,
                CompletionDate = maintenance.CompletionDate,
                MaintenanceType = maintenance.MaintenanceType,
                Description = maintenance.Description,
                Cost = maintenance.Cost,
                ServiceProvider = maintenance.ServiceProvider,
                ServiceContact = maintenance.ServiceContact,
                Status = maintenance.Status,
                CreatedAt = maintenance.CreatedAt
            };
        }

        private VehicleVM MapToVehicleVM(Vehicle vehicle)
        {
            return new VehicleVM
            {
                Id = vehicle.Id,
                PlateNumber = vehicle.PlateNumber,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                VehicleType = vehicle.VehicleType,
                Status = vehicle.Status,
                IsAvailable = vehicle.IsAvailable,
                IsActive = vehicle.IsActive,
             
                CreatedAt = vehicle.CreatedAt
            };
        }
    }
}