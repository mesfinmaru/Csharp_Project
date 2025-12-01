using Microsoft.EntityFrameworkCore;

namespace CRMdataLayer
{
    public class AppDBContext : DbContext
    {
        // This configures the connection to your LocalDB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=CarRentalDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        // The tables in your database
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
    }
}