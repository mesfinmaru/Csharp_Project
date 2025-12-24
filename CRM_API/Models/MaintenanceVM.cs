using System;

namespace CRM_API.Models
{
    public class MaintenanceVM
    {
        public int Id { get; set; }

        // Vehicle Information
        public int VehicleId { get; set; }
        public string VehiclePlateNumber { get; set; } = "";
        public string VehicleMake { get; set; } = "";
        public string VehicleModel { get; set; } = "";
        public int CurrentMileage { get; set; }

        // Maintenance Details
        public DateTime MaintenanceDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string MaintenanceType { get; set; } = ""; // Regular, Repair, Emergency
        public string Description { get; set; } = "";
        public decimal Cost { get; set; }
        public string ServiceProvider { get; set; } = "";
        public string ServiceContact { get; set; } = "";

        // Status
        public string Status { get; set; } = "Scheduled"; // Scheduled, In Progress, Completed, Cancelled
        public bool IsActive { get; set; } = true;

        // System
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Next Service
        public DateTime? NextMaintenanceDate { get; set; }
        public int? NextServiceKm { get; set; }

        // Calculated Properties
        public bool IsOverdue => Status == "Scheduled" && MaintenanceDate < DateTime.Today;
        public int DaysOverdue => IsOverdue ? (DateTime.Today - MaintenanceDate).Days : 0;
        public string VehicleInfo => $"{VehiclePlateNumber} - {VehicleMake} {VehicleModel}";
    }
}