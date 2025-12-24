namespace CRM_API.Models
{
    public class RentalReportVM
    {
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; } = "";
        public List<RentalVM> Rentals { get; set; } = new List<RentalVM>();
        public decimal TotalRevenue { get; set; }
        public int TotalRentals { get; set; }
        public int ActiveRentals { get; set; }
        public int CompletedRentals { get; set; }
        public int OverdueRentals { get; set; }
    }

    public class MaintenanceReportVM
    {
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; } = "";
        public List<MaintenanceVM> Maintenances { get; set; } = new List<MaintenanceVM>();
        public decimal TotalCost { get; set; }
        public int TotalMaintenances { get; set; }
        public int ScheduledCount { get; set; }
        public int InProgressCount { get; set; }
        public int CompletedCount { get; set; }
        public int OverdueCount { get; set; }
    }

    public class VehicleReportVM
    {
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; } = "";
        public List<VehicleVM> Vehicles { get; set; } = new List<VehicleVM>();
        public int TotalVehicles { get; set; }
        public int AvailableVehicles { get; set; }
        public int RentedVehicles { get; set; }
        public int InMaintenanceVehicles { get; set; }
        public decimal TotalVehicleValue { get; set; }
    }

    public class FinancialReportVM
    {
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalMaintenanceCost { get; set; }
        public decimal NetProfit { get; set; }
        public List<RentalVM> Rentals { get; set; } = new List<RentalVM>();
        public List<MaintenanceVM> Maintenances { get; set; } = new List<MaintenanceVM>();
    }
}