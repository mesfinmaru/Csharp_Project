using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMdataLayer.Entities
{
    [Table("Maintenances")]
    public class Maintenance
    {
        [Key]
        [Column("id")]  // Map to lowercase 'id' column in database
        public int Id { get; set; }

        // Vehicle Information
        [ForeignKey("Vehicle")]
        [Column("VehicleId")]
        public int VehicleId { get; set; }

        public virtual Vehicle? Vehicle { get; set; }

        [Column("CurrentWileage")]  // Critical: Map to column with typo 'Wileage'
        public int CurrentMileage { get; set; }

        // Maintenance Details
        [Column("MaintenanceDate")]
        public DateTime MaintenanceDate { get; set; }

        [Column("CompletionDate")]
        public DateTime? CompletionDate { get; set; }

        [Column("MaintenanceType")]
        public string MaintenanceType { get; set; } = "";

        [Column("Description")]
        public string Description { get; set; } = "";

        [Column("Cost")]
        public decimal Cost { get; set; }

        [Column("ServiceProvider")]
        public string ServiceProvider { get; set; } = "";

        [Column("ServiceContact")]
        public string ServiceContact { get; set; } = "";

        // Status
        [Column("Status")]
        public string Status { get; set; } = "Scheduled";

        [Column("IsActive")]
        public bool IsActive { get; set; } = true;

        // Next Service
        [Column("NextMaintenanceDate")]
        public DateTime? NextMaintenanceDate { get; set; }

        [Column("NextServiceKm")]
        public int? NextServiceKm { get; set; }

        // System
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}