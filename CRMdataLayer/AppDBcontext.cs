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
                optionsBuilder.UseSqlServer("Server =.; Database = CarRentalDB1; user Id = sa; Password = 12345678; MultipleActiveResultSets = true; TrustServerCertificate = True; ");
            }
        }
        // DbSet properties
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
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

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Year)
                    .IsRequired();

                entity.Property(e => e.Color)
                    .HasMaxLength(30);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(30);

                entity.Property(e => e.Transmission)
                    .HasMaxLength(20);

                entity.Property(e => e.FuelType)
                    .HasMaxLength(20);

                entity.Property(e => e.VIN)
                    .HasMaxLength(17);

                entity.Property(e => e.EngineNumber)
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Available");

                entity.Property(e => e.DailyRate)
                    .HasPrecision(18, 2);

                entity.Property(e => e.WeeklyRate)
                    .HasPrecision(18, 2);

                entity.Property(e => e.MonthlyRate)
                    .HasPrecision(18, 2);

                // Add indexes
                entity.HasIndex(e => e.PlateNumber)
                    .IsUnique();

                entity.HasIndex(e => e.VIN)
                    .IsUnique()
                    .HasFilter("[VIN] IS NOT NULL");

                entity.HasIndex(e => e.IsActive);
                entity.HasIndex(e => e.IsAvailable);
                entity.HasIndex(e => e.Status);
            });
            // In AppDBContext.cs

        

            // SIMPLE Maintenance configuration - match EXACT database schema
            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("Maintenances");
                entity.HasKey(e => e.id);

                // Map the typo in database column name
                entity.Property(e => e.VehicleId)
                      .HasColumnName("Vehicleld"); // lowercase L

                // Map the typo in mileage column
                entity.Property(e => e.CurrentWileage)
                      .HasColumnName("CurrentWileage");

                // Simple relationship
                entity.HasOne(m => m.Vehicle)
                      .WithMany()
                      .HasForeignKey(m => m.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

          
        }
    }

    }
  
    

