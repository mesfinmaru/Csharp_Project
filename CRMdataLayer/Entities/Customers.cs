using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMdataLayer.Entities
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string? Phone { get; set; }



        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? Country { get; set; }

        [StringLength(20)]
        public string? LicenseNumber { get; set; }

        [StringLength(50)]
        public string? LicenseType { get; set; }

        public DateTime? LicenseExpiryDate { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public bool IsActive { get; set; } = true;

     
    }
}
