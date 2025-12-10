using CRMdataLayer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;


namespace CRMdataLayer
{
    public class AppDBContext : DbContext
    {
        // Constructor with DbContextOptions
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        // Empty constructor (optional, for migrations)
        public AppDBContext()
        {
        }
        // Optional: Configure connection string for design-time (migrations)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // This is for migrations only
                optionsBuilder.UseSqlServer("Server =.; Database = CarRentalDB; user Id = sa; Password = 12345678; MultipleActiveResultSets = true; TrustServerCertificate = True; ");
            }
        }
        // DbSet properties
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
            .HasIndex(u => u.Username)
            .IsUnique();

        
        }
  
    }
}