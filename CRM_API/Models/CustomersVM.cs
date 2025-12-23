using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_API.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }

       
        public string? FullName { get; set; }

        
        public string? Email { get; set; }

        public string? Phone { get; set; }

   
        public string? Address { get; set; }

     
        public string? City { get; set; }

        public string? Country { get; set; }

   
        public string? LicenseNumber { get; set; }

   
        public string? LicenseType { get; set; }

        public DateTime? LicenseExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}