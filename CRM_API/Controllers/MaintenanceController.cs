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
    public class MaintenancesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MaintenancesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/maintenances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> GetMaintenances(string? search = null, string? status = null)
        {
            try
            {
                var query = _context.Maintenances
                    .Include(m => m.Vehicle)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(m =>
                        m.Description.Contains(search) ||
                        m.MaintenanceType.Contains(search) ||
                        m.MechanicName.Contains(search) ||
                        (m.Vehicle != null && m.Vehicle.PlateNumber.Contains(search)) ||
                        (m.Vehicle != null && m.Vehicle.Make.Contains(search)) ||
                        (m.Vehicle != null && m.Vehicle.Model.Contains(search))
                    );
                }

                if (!string.IsNullOrWhiteSpace(status) && status != "All")
                {
                    query = query.Where(m => m.Status == status);
                }

                var maintenances = await query
                    .OrderByDescending(m => m.ScheduledDate)
                    .ToListAsync();

                var result = maintenances.Select(m => new MaintenanceVM
                {
                    Id = m.id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    VehicleType = m.Vehicle?.VehicleType ?? "",
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    ScheduledDate = m.ScheduledDate,
                    CompletionDate = m.CompletionDate,
                    CurrentMileage = m.CurrentWileage,
                    Status = m.Status,
                    Cost = m.Cost,
                    MechanicName = m.MechanicName,
                    MechanicPhone = m.MechanicPhone,
                    Notes = m.Notes,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    CreatedBy = m.CreatedBy
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving maintenances: {ex.Message}");
            }
        }

        // GET: api/maintenances/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceVM>> GetMaintenance(int id)
        {
            try
            {
                var maintenance = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .FirstOrDefaultAsync(m => m.id == id); // Use lowercase id

                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                var result = new MaintenanceVM
                {
                    Id = maintenance.id,
                    VehicleId = maintenance.VehicleId,
                    VehiclePlateNumber = maintenance.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = maintenance.Vehicle?.Make ?? "",
                    VehicleModel = maintenance.Vehicle?.Model ?? "",
                    VehicleType = maintenance.Vehicle?.VehicleType ?? "",
                    MaintenanceType = maintenance.MaintenanceType,
                    Description = maintenance.Description,
                    ScheduledDate = maintenance.ScheduledDate,
                    CompletionDate = maintenance.CompletionDate,
                    CurrentMileage = maintenance.CurrentWileage,
                    Status = maintenance.Status,
                    Cost = maintenance.Cost,
                    MechanicName = maintenance.MechanicName,
                    MechanicPhone = maintenance.MechanicPhone,
                    Notes = maintenance.Notes,
                    CreatedAt = maintenance.CreatedAt,
                    UpdatedAt = maintenance.UpdatedAt,
                    CreatedBy = maintenance.CreatedBy
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving maintenance: {ex.Message}");
            }
        }

        // GET: api/maintenances/vehicle/{vehicleId}
        [HttpGet("vehicle/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> GetVehicleMaintenanceHistory(int vehicleId)
        {
            try
            {
                var maintenances = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .Where(m => m.VehicleId == vehicleId)
                    .OrderByDescending(m => m.ScheduledDate)
                    .ToListAsync();

                var result = maintenances.Select(m => new MaintenanceVM
                {
                    Id = m.id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    VehicleType = m.Vehicle?.VehicleType ?? "",
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    ScheduledDate = m.ScheduledDate,
                    CompletionDate = m.CompletionDate,
                    CurrentMileage = m.CurrentWileage,
                    Status = m.Status,
                    Cost = m.Cost,
                    MechanicName = m.MechanicName,
                    MechanicPhone = m.MechanicPhone,
                    Notes = m.Notes,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    CreatedBy = m.CreatedBy
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving vehicle maintenance history: {ex.Message}");
            }
        }

        // POST: api/maintenances
        [HttpPost]
        public async Task<ActionResult<MaintenanceVM>> CreateMaintenance(MaintenanceRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verify vehicle exists
                var vehicle = await _context.Vehicles.FindAsync(request.VehicleId);
                if (vehicle == null)
                {
                    return BadRequest("Vehicle not found");
                }

                // Check if vehicle is available
                if (!vehicle.IsAvailable)
                {
                    return BadRequest("Vehicle is currently rented and not available for maintenance");
                }

                var maintenance = new Maintenance
                {
                    VehicleId = request.VehicleId,
                    MaintenanceType = request.MaintenanceType,
                    Description = request.Description,
                    ScheduledDate = request.ScheduledDate,
                    CurrentWileage = request.CurrentMileage,
                    Cost = request.Cost,
                    MechanicName = request.MechanicName,
                    MechanicPhone = request.MechanicPhone,
                    Notes = request.Notes,
                    Status = "Scheduled",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = User.Identity?.Name ?? "System"
                };

                // Update vehicle status
                vehicle.Status = "In Maintenance";
                vehicle.IsAvailable = false;
                vehicle.UpdatedAt = DateTime.UtcNow;

                _context.Maintenances.Add(maintenance);
                await _context.SaveChangesAsync();

                var result = new MaintenanceVM
                {
                    Id = maintenance.id,
                    VehicleId = maintenance.VehicleId,
                    VehiclePlateNumber = vehicle.PlateNumber,
                    VehicleMake = vehicle.Make,
                    VehicleModel = vehicle.Model,
                    VehicleType = vehicle.VehicleType,
                    MaintenanceType = maintenance.MaintenanceType,
                    Description = maintenance.Description,
                    ScheduledDate = maintenance.ScheduledDate,
                    CompletionDate = maintenance.CompletionDate,
                    CurrentMileage = maintenance.CurrentWileage,
                    Status = maintenance.Status,
                    Cost = maintenance.Cost,
                    MechanicName = maintenance.MechanicName,
                    MechanicPhone = maintenance.MechanicPhone,
                    Notes = maintenance.Notes,
                    CreatedAt = maintenance.CreatedAt,
                    CreatedBy = maintenance.CreatedBy
                };

                return CreatedAtAction(nameof(GetMaintenance), new { id = maintenance.id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating maintenance: {ex.Message}\n\nDetails: {ex.InnerException?.Message}");
            }
        }

        // PUT: api/maintenances/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenance(int id, MaintenanceVM maintenanceVM)
        {
            try
            {
                if (id != maintenanceVM.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var maintenance = await _context.Maintenances.FindAsync(id);
                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                // Only allow updates if not completed
                if (maintenance.Status == "Completed")
                {
                    return BadRequest("Cannot update completed maintenance");
                }

                // Update allowed fields
                maintenance.MaintenanceType = maintenanceVM.MaintenanceType;
                maintenance.Description = maintenanceVM.Description;
                maintenance.ScheduledDate = maintenanceVM.ScheduledDate;
                maintenance.CurrentWileage = maintenanceVM.CurrentMileage;
                maintenance.Cost = maintenanceVM.Cost;
                maintenance.MechanicName = maintenanceVM.MechanicName;
                maintenance.MechanicPhone = maintenanceVM.MechanicPhone;
                maintenance.Notes = maintenanceVM.Notes;
                maintenance.Status = maintenanceVM.Status;
                maintenance.UpdatedAt = DateTime.UtcNow;

                // If status changed to completed, set completion date
                if (maintenanceVM.Status == "Completed" && !maintenance.CompletionDate.HasValue)
                {
                    maintenance.CompletionDate = DateTime.UtcNow;

                    // Update vehicle status back to available
                    var vehicle = await _context.Vehicles.FindAsync(maintenance.VehicleId);
                    if (vehicle != null)
                    {
                        vehicle.Status = "Available";
                        vehicle.IsAvailable = true;
                        vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating maintenance: {ex.Message}");
            }
        }

        // PUT: api/maintenances/{id}/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteMaintenance(int id, CompleteMaintenanceRequest request)
        {
            try
            {
                var maintenance = await _context.Maintenances.FindAsync(id);
                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                if (maintenance.Status == "Completed")
                {
                    return BadRequest("Maintenance already completed");
                }

                // Update maintenance
                maintenance.Status = "Completed";
                maintenance.CompletionDate = request.CompletionDate;
                if (request.ActualCost.HasValue)
                {
                    maintenance.Cost = request.ActualCost.Value;
                }
                if (!string.IsNullOrEmpty(request.Notes))
                {
                    maintenance.Notes = request.Notes;
                }
                maintenance.UpdatedAt = DateTime.UtcNow;

                // Update vehicle status
                var vehicle = await _context.Vehicles.FindAsync(maintenance.VehicleId);
                if (vehicle != null)
                {
                    // Update vehicle mileage if maintenance mileage is higher
                    if (maintenance.CurrentWileage > vehicle.Mileage)
                    {
                        vehicle.Mileage = maintenance.CurrentWileage;
                    }

                    // Update last service date
                    vehicle.LastServiceDate = request.CompletionDate;

                    // Calculate next service date (e.g., 6 months later or 5000 km)
                    vehicle.NextServiceDate = request.CompletionDate.AddMonths(6);

                    // Make vehicle available again
                    vehicle.Status = "Available";
                    vehicle.IsAvailable = true;
                    vehicle.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Maintenance completed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error completing maintenance: {ex.Message}");
            }
        }

        // PUT: api/maintenances/{id}/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartMaintenance(int id)
        {
            try
            {
                var maintenance = await _context.Maintenances.FindAsync(id);
                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                if (maintenance.Status != "Scheduled")
                {
                    return BadRequest("Only scheduled maintenance can be started");
                }

                maintenance.Status = "In Progress";
                maintenance.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Maintenance started successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error starting maintenance: {ex.Message}");
            }
        }

        // PUT: api/maintenances/{id}/cancel
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelMaintenance(int id, [FromQuery] string? reason = null)
        {
            try
            {
                var maintenance = await _context.Maintenances.FindAsync(id);
                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                if (maintenance.Status == "Completed")
                {
                    return BadRequest("Cannot cancel completed maintenance");
                }

                maintenance.Status = "Cancelled";
                if (!string.IsNullOrEmpty(reason))
                {
                    maintenance.Notes = reason;
                }
                maintenance.UpdatedAt = DateTime.UtcNow;

                // Update vehicle status back to available
                var vehicle = await _context.Vehicles.FindAsync(maintenance.VehicleId);
                if (vehicle != null)
                {
                    vehicle.Status = "Available";
                    vehicle.IsAvailable = true;
                    vehicle.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Maintenance cancelled successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error cancelling maintenance: {ex.Message}");
            }
        }

        // DELETE: api/maintenances/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance(int id)
        {
            try
            {
                var maintenance = await _context.Maintenances.FindAsync(id);
                if (maintenance == null)
                {
                    return NotFound($"Maintenance with ID {id} not found");
                }

                // Only allow deletion of cancelled or scheduled maintenance
                if (maintenance.Status == "In Progress" || maintenance.Status == "Completed")
                {
                    return BadRequest($"Cannot delete {maintenance.Status} maintenance");
                }

                // Update vehicle status if maintenance was active
                if (maintenance.Status == "Scheduled")
                {
                    var vehicle = await _context.Vehicles.FindAsync(maintenance.VehicleId);
                    if (vehicle != null && vehicle.Status == "In Maintenance")
                    {
                        vehicle.Status = "Available";
                        vehicle.IsAvailable = true;
                        vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                }

                _context.Maintenances.Remove(maintenance);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Maintenance deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting maintenance: {ex.Message}");
            }
        }

        // GET: api/maintenances/overdue
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> GetOverdueMaintenances()
        {
            try
            {
                var today = DateTime.Today;
                var overdueMaintenances = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .Where(m => m.Status == "Scheduled" && m.ScheduledDate < today)
                    .OrderBy(m => m.ScheduledDate)
                    .ToListAsync();

                var result = overdueMaintenances.Select(m => new MaintenanceVM
                {
                    Id = m.id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    VehicleType = m.Vehicle?.VehicleType ?? "",
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    ScheduledDate = m.ScheduledDate,
                    CompletionDate = m.CompletionDate,
                    CurrentMileage = m.CurrentWileage,
                    Status = m.Status,
                    Cost = m.Cost,
                    MechanicName = m.MechanicName,
                    MechanicPhone = m.MechanicPhone,
                    Notes = m.Notes,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    CreatedBy = m.CreatedBy
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving overdue maintenances: {ex.Message}");
            }
        }

        // GET: api/maintenances/upcoming
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> GetUpcomingMaintenances([FromQuery] int days = 7)
        {
            try
            {
                var today = DateTime.Today;
                var endDate = today.AddDays(days);

                var upcomingMaintenances = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .Where(m => m.Status == "Scheduled" && m.ScheduledDate >= today && m.ScheduledDate <= endDate)
                    .OrderBy(m => m.ScheduledDate)
                    .ToListAsync();

                var result = upcomingMaintenances.Select(m => new MaintenanceVM
                {
                    Id = m.id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    VehicleType = m.Vehicle?.VehicleType ?? "",
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    ScheduledDate = m.ScheduledDate,
                    CompletionDate = m.CompletionDate,
                    CurrentMileage = m.CurrentWileage,
                    Status = m.Status,
                    Cost = m.Cost,
                    MechanicName = m.MechanicName,
                    MechanicPhone = m.MechanicPhone,
                    Notes = m.Notes,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    CreatedBy = m.CreatedBy
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving upcoming maintenances: {ex.Message}");
            }
        }

        // GET: api/maintenances/stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetMaintenanceStats()
        {
            try
            {
                var stats = new
                {
                    TotalMaintenances = await _context.Maintenances.CountAsync(),
                    Scheduled = await _context.Maintenances.CountAsync(m => m.Status == "Scheduled"),
                    InProgress = await _context.Maintenances.CountAsync(m => m.Status == "In Progress"),
                    Completed = await _context.Maintenances.CountAsync(m => m.Status == "Completed"),
                    Cancelled = await _context.Maintenances.CountAsync(m => m.Status == "Cancelled"),
                    Overdue = await _context.Maintenances.CountAsync(m =>
                        m.Status == "Scheduled" && m.ScheduledDate < DateTime.Today),
                    TotalCost = await _context.Maintenances.Where(m => m.Status == "Completed").SumAsync(m => m.Cost),
                    AverageCost = await _context.Maintenances.Where(m => m.Status == "Completed")
                        .AverageAsync(m => (double?)m.Cost) ?? 0
                };

                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving maintenance stats: {ex.Message}");
            }
        }

        // GET: api/maintenances/debug/verify
        [HttpGet("debug/verify")]
        public async Task<IActionResult> VerifyDatabaseConnection()
        {
            try
            {
                var tableExists = await _context.Database.ExecuteSqlRawAsync(
                    "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Maintenances') THEN 1 ELSE 0 END") == 1;

                if (!tableExists)
                {
                    return Ok(new { success = false, message = "Maintenances table does not exist" });
                }

                var recordCount = await _context.Maintenances.CountAsync();
                var sampleRecord = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .FirstOrDefaultAsync();

                return Ok(new
                {
                    success = true,
                    message = $"Database connection successful. Maintenances table exists with {recordCount} records.",
                    tableExists = true,
                    recordCount = recordCount,
                    sampleRecord = sampleRecord != null ? new
                    {
                        Id = sampleRecord.id,
                        VehicleId = sampleRecord.VehicleId,
                        Vehicle = sampleRecord.Vehicle?.PlateNumber ?? "No Vehicle",
                        MaintenanceType = sampleRecord.MaintenanceType,
                        Status = sampleRecord.Status
                    } : null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Database error: {ex.Message}",
                    innerException = ex.InnerException?.Message,
                    details = ex.ToString()
                });
            }
        }
    }
}