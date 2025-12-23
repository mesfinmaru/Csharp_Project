using CRMdataLayer;
using CRMdataLayer.Entities;
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

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);

                // Add index for username
                entity.HasIndex(e => e.Username).IsUnique();


            });

            // Customer configuration
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.LicenseNumber).HasMaxLength(20);
                entity.Property(e => e.LicenseType).HasMaxLength(50);

                // Add indexes
                entity.HasIndex(e => e.Phone).IsUnique();
                entity.HasIndex(e => e.Email);
                entity.HasIndex(e => e.IsActive);
            });
        }
  
    }
}
