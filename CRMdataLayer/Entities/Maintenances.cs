using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMdataLayer.Entities
{
    [Table("Maintenances")]
    public class Maintenance
    {
        [Key]
        public int id { get; set; }

        // IMPORTANT: Database has typo "Vehicleld" (with lowercase L) not "VehicleId"
        [Column("Vehicleld")] // Match the typo in database
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle { get; set; }

        public string MaintenanceType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        // Database has typo "CurrentWileage" not "CurrentMileage"
        public int CurrentWileage { get; set; }

        public string Status { get; set; } = "Scheduled";
        public decimal Cost { get; set; }
        public string? Notes { get; set; }
        public string MechanicName { get; set; } = string.Empty;
        public string? MechanicPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = "System";
    }
}