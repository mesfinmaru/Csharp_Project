using System;
using System.Collections.Generic;

namespace CRM_API.Models
{
    // Report View Models
    public class CustomerReportVM
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TotalRentals { get; set; }
        public decimal TotalSpent { get; set; }
        public bool IsActive { get; set; }
    }

    public class RentalReportVM
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string VehicleInfo { get; set; }
        public string VehicleType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int RentalDays { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
    }

    public class VehicleReportVM
    {
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
        public int TimesRented { get; set; }
        public decimal TotalRevenue { get; set; }
        public string Status { get; set; }
    }

    public class FinancialReportVM
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public string CustomerName { get; set; }
        public string VehicleInfo { get; set; }
        public decimal Revenue { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public string TransactionId { get; set; }
    }

    public class OverdueReportVM
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string VehicleInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int DaysOverdue { get; set; }
        public decimal? LateFee { get; set; }
    }

    public class ReportSummaryVM
    {
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int TotalRecords { get; set; }
        public decimal TotalRevenue { get; set; }
        public int ActiveRentals { get; set; }
        public int OverdueRentals { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalVehicles { get; set; }
    }

    // Report Request Models
    public class ReportRequest
    {
        public string ReportType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Status { get; set; }
        public string VehicleType { get; set; }
        public bool IncludeAllDates { get; set; }
    }
}