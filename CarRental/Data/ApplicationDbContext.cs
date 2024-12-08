using CarRental.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarRental.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<RentalVehicle> RentalVehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Seed ApplicationUser
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "user1",
                    UserName = "user1@example.com",
                    Email = "user1@example.com",
                    Role = Role.User,
                    NormalizedUserName = "USER1@EXAMPLE.COM",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!")
                },
                new ApplicationUser
                {
                    Id = "user2",
                    UserName = "user2@example.com",
                    Email = "user2@example.com",
                    Role = Role.User,
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!")
                },
                new ApplicationUser
                {
                    Id = "owner1",
                    UserName = "owner1@example.com",
                    Email = "owner1@example.com",
                    Role = Role.User,
                    NormalizedUserName = "OWNER1@EXAMPLE.COM",
                    NormalizedEmail = "OWNER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!")
                },
                new ApplicationUser
                {
                    Id = "owner2",
                    UserName = "owner2@example.com",
                    Email = "owner2@example.com",
                    Role = Role.User,
                    NormalizedUserName = "OWNER2@EXAMPLE.COM",
                    NormalizedEmail = "OWNER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!")
                }
            };

            builder.Entity<ApplicationUser>().HasData(users);

            // Seed RentalVehicle
            var vehicles = new List<RentalVehicle>
            {
                new RentalVehicle
                {
                    RentalVehicleID = 1,
                    LicensePlate = "ABC-1234",
					OwnerId = users[2].Id, // owner1
                    Brand = "Toyota",
                    Model = "Corolla",
                    ManuYear = new DateTime(2018,1,1),
                    NumberOfSeats = 4,
                    Description = "Toyota 50 negiotable",
					RentalFeePerKilo = 50.5f,
                    RentalFeePerDay = 712,
					TimeCreated = DateTime.Now,
                },
                new RentalVehicle
                {
                    RentalVehicleID = 2,
					LicensePlate = "DL05 XY5678",
					OwnerId = users[3].Id, // owner2
                    Brand = "Honda",
                    Model = "Civic",
                    ManuYear = new DateTime(2018,1,1),
                    NumberOfSeats = 4,
					Description = "For rental negiotable",
                    RentalFeePerKilo = 60,
                    RentalFeePerDay = 800,
					TimeCreated = DateTime.Now,
				},
                new RentalVehicle
                {
                    RentalVehicleID = 3,
					LicensePlate = "GH78 JKL",
					OwnerId = users[2].Id, // owner1
                    Brand = "Ford",
                    Model = "Focus",
					ManuYear = new DateTime(2017,1,1),
					NumberOfSeats = 4,
					Description = "For rental",
					RentalFeePerKilo = 66.3f,
					RentalFeePerDay = 900.2f,
					TimeCreated = DateTime.Now,
				}
            };
			builder.Entity<RentalVehicle>()
		        .Property(r => r.RentalFeePerDay)
		        .HasColumnType("REAL"); // Use appropriate database column type
			builder.Entity<RentalVehicle>().HasData(vehicles);

            // Seed Rental
            var rentals = new List<Rental>
            {
                new Rental
                {
                    RentalId = 1,
                    UserID = users[0].Id, // user1
                    RentalVehicleID = vehicles[0].RentalVehicleID,
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now.AddDays(2),
                    Status = Status.Confirmed
                },
                new Rental
                {
                    RentalId = 2,
                    UserID = users[1].Id, // user2
                    RentalVehicleID = vehicles[1].RentalVehicleID,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(4),
                    Status = Status.Pending
                },
                new Rental
                {
                    RentalId = 3,
                    UserID = users[0].Id, // user1
                    RentalVehicleID = vehicles[2].RentalVehicleID,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Status = Status.Cancelled
                }
            };

            builder.Entity<Rental>().HasData(rentals);
        }
    }
}
