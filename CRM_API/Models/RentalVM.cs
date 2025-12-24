using System;

namespace CRM_API.Models
{
    public class RentalVM
    {
        public int Id { get; set; }

        // Customer Information
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerLicense { get; set; }

        // Vehicle Information
        public int VehicleId { get; set; }
        public string? VehiclePlateNumber { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleColor { get; set; }
        public string? VehicleType { get; set; }

        // Rental Period
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        // Pricing
        public decimal DailyRate { get; set; }
        public int RentalDays { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceDue { get; set; }

        // Payment
        public bool IsPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentNotes { get; set; }

        // Status
        public string? Status { get; set; } // Active, Completed, Cancelled
        public bool IsActive { get; set; }

        // Notes
        public string? Notes { get; set; }

        // System
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Calculated Properties
        public bool IsOverdue => Status == "Active" && DateTime.Now > EndDate;
        public int DaysOverdue => Status == "Active" && DateTime.Now > EndDate ?
            (DateTime.Now - EndDate).Days : 0;
    }
    public class ReturnRequest
    {
        public DateTime ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public string? Notes { get; set; }
    }
}