using System;

namespace CRM_API.Models
{
    public class MaintenanceVM
    {
        public int Id { get; set; }

        // Vehicle Information
        public int VehicleId { get; set; }
        public string? VehiclePlateNumber { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleType { get; set; }

        // Maintenance Details
        public string MaintenanceType { get; set; } = string.Empty; // Regular Service, Repair, Accident Repair, etc.
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int CurrentMileage { get; set; }

        // Status
        public string Status { get; set; } = "Scheduled"; // Scheduled, In Progress, Completed, Cancelled

        // Cost
        public decimal Cost { get; set; }

        // Mechanic Information
        public string MechanicName { get; set; } = string.Empty;
        public string? MechanicPhone { get; set; }

        // Notes
        public string? Notes { get; set; }

        // System
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        // Calculated Properties
        public bool IsOverdue => Status == "Scheduled" && ScheduledDate < DateTime.Today;
        public bool IsInProgress => Status == "In Progress";
        public bool IsCompleted => Status == "Completed";
        public int? DaysUntilDue => Status == "Scheduled" ?
            (ScheduledDate - DateTime.Today).Days : null;
    }

    public class MaintenanceRequest
    {
        public int VehicleId { get; set; }
        public string MaintenanceType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public int CurrentMileage { get; set; }
        public decimal Cost { get; set; }
        public string MechanicName { get; set; } = string.Empty;
        public string? MechanicPhone { get; set; }
        public string? Notes { get; set; }
    }

    public class CompleteMaintenanceRequest
    {
        public DateTime CompletionDate { get; set; }
        public decimal? ActualCost { get; set; }
        public string? Notes { get; set; }
    }
}