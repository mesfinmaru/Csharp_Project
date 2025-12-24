namespace CRMdataLayer.Entities
{
    public class Rentals
    {
        public int Id { get; set; }

        // Foreign Keys
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        // Navigation Properties
        public virtual Customers? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }

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

        // Payment Verification
        public bool IsPaid { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentNotes { get; set; }

        // Status
        public string? Status { get; set; } // Reserved, Active, Completed, Cancelled
        public bool IsActive { get; set; }

        // Notes
        public string? Notes { get; set; }

        // System
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}