using Microsoft.EntityFrameworkCore;

namespace CRMdataLayer
{
    public class AppDBContext : DbContext
    {
        // 1. ADD THIS CONSTRUCTOR so Program.cs can pass settings
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        // 2. KEEP THIS CONSTRUCTOR so your manual "new AppDBContext()" calls still work
        public AppDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only use the hardcoded string if no options were provided by Program.cs
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=CarRentalDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
    }
}