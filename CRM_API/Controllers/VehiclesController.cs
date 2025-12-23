using CRM_API.Models;
using CRMdataLayer;
using CRMdataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public VehiclesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleVM>>> Get(string? search = null)
        {
            try
            {
                var query = _context.Vehicles.AsQueryable();

                // Apply search filter if provided
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(v =>
                        (v.PlateNumber != null && v.PlateNumber.Contains(search)) ||
                        (v.Make != null && v.Make.Contains(search)) ||
                        (v.Model != null && v.Model.Contains(search)) ||
                        (v.VIN != null && v.VIN.Contains(search))
                    );
                }

                var vehicles = await query.ToListAsync();

                // Map to VehicleVM
                var vehicleVMs = vehicles.Select(v => new VehicleVM
                {
                    Id = v.Id,
                    PlateNumber = v.PlateNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Year = v.Year,
                    Color = v.Color,
                    VehicleType = v.VehicleType,
                    Transmission = v.Transmission,
                    FuelType = v.FuelType,
                    Seats = v.Seats,
                    Mileage = v.Mileage,
                    VIN = v.VIN,
                    EngineNumber = v.EngineNumber,
                    Features = v.Features,
                    DailyRate = v.DailyRate,
                    WeeklyRate = v.WeeklyRate,
                    MonthlyRate = v.MonthlyRate,
                    Status = "Available", // You need to add Status property to Vehicle entity
                    IsActive = v.IsActive,
                    IsAvailable = v.IsAvailable,
                    CreatedAt = v.CreatedAt,
                    UpdatedAt = v.UpdatedAt,
                    LastServiceDate = v.LastServiceDate,
                    NextServiceDate = v.NextServiceDate,
                    Notes = v.Notes
                }).ToList();

                return Ok(vehicleVMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving vehicles: {ex.Message}" });
            }
        }

        // GET: api/vehicles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleVM>> Get(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(id);
                if (vehicle == null)
                {
                    return NotFound(new { message = $"Vehicle with ID {id} not found" });
                }

                // Map to VehicleVM
                var vehicleVM = new VehicleVM
                {
                    Id = vehicle.Id,
                    PlateNumber = vehicle.PlateNumber,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    Color = vehicle.Color,
                    VehicleType = vehicle.VehicleType,
                    Transmission = vehicle.Transmission,
                    FuelType = vehicle.FuelType,
                    Seats = vehicle.Seats,
                    Mileage = vehicle.Mileage,
                    VIN = vehicle.VIN,
                    EngineNumber = vehicle.EngineNumber,
                    Features = vehicle.Features,
                    DailyRate = vehicle.DailyRate,
                    WeeklyRate = vehicle.WeeklyRate,
                    MonthlyRate = vehicle.MonthlyRate,
                    Status = "Available", // You need to add Status property to Vehicle entity
                    IsActive = vehicle.IsActive,
                    IsAvailable = vehicle.IsAvailable,
                    CreatedAt = vehicle.CreatedAt,
                    UpdatedAt = vehicle.UpdatedAt,
                    LastServiceDate = vehicle.LastServiceDate,
                    NextServiceDate = vehicle.NextServiceDate,
                    Notes = vehicle.Notes
                };

                return Ok(vehicleVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving vehicle: {ex.Message}" });
            }
        }

        // POST: api/vehicles
        [HttpPost]
        public async Task<ActionResult<VehicleVM>> Post([FromBody] VehicleVM vehicleVM)
        {
            try
            {
                if (vehicleVM == null)
                {
                    return BadRequest(new { message = "Vehicle data is required" });
                }

                // Validation
                if (string.IsNullOrWhiteSpace(vehicleVM.PlateNumber))
                {
                    return BadRequest(new { message = "Plate number is required" });
                }

                // Check if plate number already exists
                var existingPlate = await _context.Vehicles
                    .AnyAsync(v => v.PlateNumber != null && v.PlateNumber.ToLower() == vehicleVM.PlateNumber.ToLower());

                if (existingPlate)
                {
                    return BadRequest(new { message = "Plate number already exists" });
                }

                // Map to Vehicle entity
                var vehicle = new Vehicle
                {
                    PlateNumber = vehicleVM.PlateNumber,
                    Make = vehicleVM.Make,
                    Model = vehicleVM.Model,
                    Year = vehicleVM.Year,
                    Color = vehicleVM.Color,
                    VehicleType = vehicleVM.VehicleType,
                    Transmission = vehicleVM.Transmission,
                    FuelType = vehicleVM.FuelType,
                    Seats = vehicleVM.Seats,
                    Mileage = vehicleVM.Mileage,
                    VIN = vehicleVM.VIN,
                    EngineNumber = vehicleVM.EngineNumber,
                    Features = vehicleVM.Features,
                    DailyRate = vehicleVM.DailyRate,
                    WeeklyRate = vehicleVM.WeeklyRate,
                    MonthlyRate = vehicleVM.MonthlyRate,
                    IsActive = vehicleVM.IsActive,
                    IsAvailable = vehicleVM.IsAvailable,
                    CreatedAt = DateTime.UtcNow,
                    LastServiceDate = vehicleVM.LastServiceDate,
                    NextServiceDate = vehicleVM.NextServiceDate,
                    Notes = vehicleVM.Notes
                };

                // Add to database
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync(); // THIS SAVES TO DATABASE

                // Return the created vehicle with ID
                vehicleVM.Id = vehicle.Id;
                vehicleVM.CreatedAt = vehicle.CreatedAt;

                return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicleVM);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error creating vehicle: {ex.Message}" });
            }
        }

        // PUT: api/vehicles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleVM updatedVehicleVM)
        {
            try
            {
                var existingVehicle = await _context.Vehicles.FindAsync(id);
                if (existingVehicle == null)
                {
                    return NotFound(new { message = $"Vehicle with ID {id} not found" });
                }

                // Check if plate number already exists for another vehicle
                var duplicatePlate = await _context.Vehicles
                    .AnyAsync(v => v.Id != id &&
                           v.PlateNumber != null &&
                           v.PlateNumber.ToLower() == updatedVehicleVM.PlateNumber.ToLower());

                if (duplicatePlate)
                {
                    return BadRequest(new { message = "Plate number already exists for another vehicle" });
                }

                // Update properties
                existingVehicle.PlateNumber = updatedVehicleVM.PlateNumber;
                existingVehicle.Make = updatedVehicleVM.Make;
                existingVehicle.Model = updatedVehicleVM.Model;
                existingVehicle.Year = updatedVehicleVM.Year;
                existingVehicle.Color = updatedVehicleVM.Color;
                existingVehicle.VehicleType = updatedVehicleVM.VehicleType;
                existingVehicle.Transmission = updatedVehicleVM.Transmission;
                existingVehicle.FuelType = updatedVehicleVM.FuelType;
                existingVehicle.Mileage = updatedVehicleVM.Mileage;
                existingVehicle.Seats = updatedVehicleVM.Seats;
                existingVehicle.Features = updatedVehicleVM.Features;
                existingVehicle.DailyRate = updatedVehicleVM.DailyRate;
                existingVehicle.WeeklyRate = updatedVehicleVM.WeeklyRate;
                existingVehicle.MonthlyRate = updatedVehicleVM.MonthlyRate;
                existingVehicle.IsAvailable = updatedVehicleVM.IsAvailable;
                existingVehicle.IsActive = updatedVehicleVM.IsActive;
                existingVehicle.VIN = updatedVehicleVM.VIN;
                existingVehicle.EngineNumber = updatedVehicleVM.EngineNumber;
                existingVehicle.LastServiceDate = updatedVehicleVM.LastServiceDate;
                existingVehicle.NextServiceDate = updatedVehicleVM.NextServiceDate;
                existingVehicle.Notes = updatedVehicleVM.Notes;
                existingVehicle.UpdatedAt = DateTime.UtcNow;

                // Save changes to database
                await _context.SaveChangesAsync();

                return Ok(updatedVehicleVM);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(id))
                {
                    return NotFound(new { message = $"Vehicle with ID {id} not found" });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating vehicle: {ex.Message}" });
            }
        }

        // DELETE: api/vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(id);
                if (vehicle == null)
                {
                    return NotFound(new { message = $"Vehicle with ID {id} not found" });
                }

                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync(); // THIS SAVES TO DATABASE

                return Ok(new { message = "Vehicle deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting vehicle: {ex.Message}" });
            }
        }

        private async Task<bool> VehicleExists(int id)
        {
            return await _context.Vehicles.AnyAsync(e => e.Id == id);
        }
    }
}