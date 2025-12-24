using System;
using System.ComponentModel.DataAnnotations;

namespace CRMdataLayer.Entities
{
    public class Maintenance
    {
        [Key]
        public int Id { get; set; }

        // Vehicle Information
        public int VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
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

        // Next Service
        public DateTime? NextMaintenanceDate { get; set; }
        public int? NextServiceKm { get; set; }

        // System
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}