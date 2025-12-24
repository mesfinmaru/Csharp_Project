using CRM_API.Models;
using CRMdataLayer;
using CRMdataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MaintenancesController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> Get(string? search = null)
        {
            try
            {
                var query = _context.Maintenances
                    .Include(m => m.Vehicle)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(m =>
                        (m.Vehicle != null && m.Vehicle.PlateNumber != null && m.Vehicle.PlateNumber.Contains(search)) ||
                        (m.ServiceProvider != null && m.ServiceProvider.Contains(search)) ||
                        (m.Status != null && m.Status.Contains(search)) ||
                        (m.MaintenanceType != null && m.MaintenanceType.Contains(search))
                    );
                }

                var maintenances = await query.OrderByDescending(m => m.CreatedAt).ToListAsync();

                var maintenanceVMs = maintenances.Select(m => new MaintenanceVM
                {
                    Id = m.Id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    CurrentMileage = m.CurrentMileage,
                    MaintenanceDate = m.MaintenanceDate,
                    CompletionDate = m.CompletionDate,
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    Cost = m.Cost,
                    ServiceProvider = m.ServiceProvider,
                    ServiceContact = m.ServiceContact,
                    Status = m.Status,
                    IsActive = m.IsActive,
                    NextMaintenanceDate = m.NextMaintenanceDate,
                    NextServiceKm = m.NextServiceKm,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt
                }).ToList();

                return Ok(maintenanceVMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving maintenances: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceVM>> Get(int id)
        {
            try
            {
                var maintenance = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (maintenance == null)
                {
                    return NotFound(new { message = $"Maintenance with ID {id} not found" });
                }

                var maintenanceVM = new MaintenanceVM
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
                    IsActive = maintenance.IsActive,
                    NextMaintenanceDate = maintenance.NextMaintenanceDate,
                    NextServiceKm = maintenance.NextServiceKm,
                    CreatedAt = maintenance.CreatedAt,
                    UpdatedAt = maintenance.UpdatedAt
                };

                return Ok(maintenanceVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving maintenance: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceVM>> Post([FromBody] MaintenanceVM maintenanceVM)
        {
            try
            {
                if (maintenanceVM == null)
                {
                    return BadRequest(new { message = "Maintenance data is required" });
                }

                // Validate vehicle exists
                var vehicle = await _context.Vehicles.FindAsync(maintenanceVM.VehicleId);
                if (vehicle == null)
                {
                    return BadRequest(new { message = "Vehicle not found" });
                }

                var maintenance = new Maintenance
                {
                    VehicleId = maintenanceVM.VehicleId,
                    CurrentMileage = maintenanceVM.CurrentMileage,
                    MaintenanceDate = maintenanceVM.MaintenanceDate,
                    CompletionDate = maintenanceVM.CompletionDate,
                    MaintenanceType = maintenanceVM.MaintenanceType,
                    Description = maintenanceVM.Description,
                    Cost = maintenanceVM.Cost,
                    ServiceProvider = maintenanceVM.ServiceProvider,
                    ServiceContact = maintenanceVM.ServiceContact,
                    Status = maintenanceVM.Status,
                    IsActive = maintenanceVM.IsActive,
                    NextMaintenanceDate = maintenanceVM.NextMaintenanceDate,
                    NextServiceKm = maintenanceVM.NextServiceKm,
                    CreatedAt = DateTime.UtcNow
                };

                // Update vehicle status if maintenance is active
                if (maintenance.Status == "In Progress")
                {
                    vehicle.Status = "In Maintenance";
                    vehicle.UpdatedAt = DateTime.UtcNow;
                }

                _context.Maintenances.Add(maintenance);
                await _context.SaveChangesAsync();

                maintenanceVM.Id = maintenance.Id;
                maintenanceVM.CreatedAt = maintenance.CreatedAt;

                return CreatedAtAction(nameof(Get), new { id = maintenance.Id }, maintenanceVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error creating maintenance: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MaintenanceVM maintenanceVM)
        {
            try
            {
                var maintenance = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (maintenance == null)
                {
                    return NotFound(new { message = $"Maintenance with ID {id} not found" });
                }

                // Store old status for comparison
                string oldStatus = maintenance.Status;

                // Update maintenance
                maintenance.CurrentMileage = maintenanceVM.CurrentMileage;
                maintenance.MaintenanceDate = maintenanceVM.MaintenanceDate;
                maintenance.CompletionDate = maintenanceVM.CompletionDate;
                maintenance.MaintenanceType = maintenanceVM.MaintenanceType;
                maintenance.Description = maintenanceVM.Description;
                maintenance.Cost = maintenanceVM.Cost;
                maintenance.ServiceProvider = maintenanceVM.ServiceProvider;
                maintenance.ServiceContact = maintenanceVM.ServiceContact;
                maintenance.Status = maintenanceVM.Status;
                maintenance.IsActive = maintenanceVM.IsActive;
                maintenance.NextMaintenanceDate = maintenanceVM.NextMaintenanceDate;
                maintenance.NextServiceKm = maintenanceVM.NextServiceKm;
                maintenance.UpdatedAt = DateTime.UtcNow;

                // Update vehicle status based on maintenance status change
                if (maintenance.Vehicle != null)
                {
                    if (oldStatus != "Completed" && maintenanceVM.Status == "Completed")
                    {
                        // Maintenance completed, vehicle available again
                        maintenance.Vehicle.Status = "Available";
                        maintenance.Vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                    else if (oldStatus != "In Progress" && maintenanceVM.Status == "In Progress")
                    {
                        // Maintenance started, vehicle in maintenance
                        maintenance.Vehicle.Status = "In Maintenance";
                        maintenance.Vehicle.UpdatedAt = DateTime.UtcNow;
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(maintenanceVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating maintenance: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var maintenance = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (maintenance == null)
                {
                    return NotFound(new { message = $"Maintenance with ID {id} not found" });
                }

                // Update vehicle status if maintenance was in progress
                if (maintenance.Vehicle != null && maintenance.Status == "In Progress")
                {
                    maintenance.Vehicle.Status = "Available";
                    maintenance.Vehicle.UpdatedAt = DateTime.UtcNow;
                }

                _context.Maintenances.Remove(maintenance);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Maintenance deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting maintenance: {ex.Message}" });
            }
        }

        [HttpGet("vehicle/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<MaintenanceVM>>> GetVehicleMaintenanceHistory(int vehicleId)
        {
            try
            {
                var maintenances = await _context.Maintenances
                    .Include(m => m.Vehicle)
                    .Where(m => m.VehicleId == vehicleId)
                    .OrderByDescending(m => m.MaintenanceDate)
                    .ToListAsync();

                var maintenanceVMs = maintenances.Select(m => new MaintenanceVM
                {
                    Id = m.Id,
                    VehicleId = m.VehicleId,
                    VehiclePlateNumber = m.Vehicle?.PlateNumber ?? "Unknown",
                    VehicleMake = m.Vehicle?.Make ?? "",
                    VehicleModel = m.Vehicle?.Model ?? "",
                    CurrentMileage = m.CurrentMileage,
                    MaintenanceDate = m.MaintenanceDate,
                    CompletionDate = m.CompletionDate,
                    MaintenanceType = m.MaintenanceType,
                    Description = m.Description,
                    Cost = m.Cost,
                    ServiceProvider = m.ServiceProvider,
                    ServiceContact = m.ServiceContact,
                    Status = m.Status,
                    IsActive = m.IsActive,
                    NextMaintenanceDate = m.NextMaintenanceDate,
                    NextServiceKm = m.NextServiceKm,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt
                }).ToList();

                return Ok(maintenanceVMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving vehicle maintenance history: {ex.Message}" });
            }
        }
    }
}