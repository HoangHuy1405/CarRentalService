﻿using CarRental.Models;
using CarRental.Models.ShareDrive;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarRental.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<DriverRide> DriverRides { get; set; }
		public DbSet<PassengerRide> PassengerRides { get; set; }

        public DbSet<Notification> Notifications { get; set; }
		public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            // Configure PassengerRide -> DriverRide relationship
            modelBuilder.Entity<Driver>()
				.HasOne(d => d.User)
				.WithOne(u => u.Driver)
				.HasForeignKey<Driver>(d => d.UserID)
				.OnDelete(DeleteBehavior.Restrict); // No cascading delete

            modelBuilder.Entity<PassengerRide>()
                .HasOne(pr => pr.Passenger)
                .WithMany(u => u.PassengerRides)
                .HasForeignKey(pr => pr.PassengerID)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete

            modelBuilder.Entity<PassengerRide>()
                .HasOne(pr => pr.DriverRide)
                .WithMany(dr => dr.PassengerRides)
                .HasForeignKey(pr => pr.DriverRideID)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete

            modelBuilder.Entity<Ticket>()
				.HasOne(t => t.PassengerRide)
				.WithOne(pr => pr.Ticket)
				.HasForeignKey<Ticket>(t => t.PassengerRideID) // Foreign key for Ticket
				.OnDelete(DeleteBehavior.Cascade); // Choose delete behavior, Cascade here

            SeedData(modelBuilder);

        }
        public void SeedData(ModelBuilder modelBuilder) {
            // Seed Roles into AspNetRoles (with generated GUIDs for RoleId)
            var adminRoleId = Guid.NewGuid().ToString();
            var driverRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            // Seed Roles into AspNetRoles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = driverRoleId, Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );
            // Seed ApplicationUser entities
            var users = new List<ApplicationUser>
			{
				new ApplicationUser
				{
					Id = "user1",
					UserName = "user1",
					Email = "user1@example.com",
					//Role = Role.User,
					NormalizedUserName = "USER1@EXAMPLE.COM",
					NormalizedEmail = "USER1@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!"),
                    Balance = 1000000
                },
				new ApplicationUser
				{
					Id = "user2",
					UserName = "user2@example.co",
					Email = "user2@example.com",
					//Role = Role.User,
					NormalizedUserName = "USER2@EXAMPLE.COM",
					NormalizedEmail = "USER2@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!"),
                    Balance = 1000000
                },
				new ApplicationUser
				{
					Id = "owner1",
					UserName = "owner1",
					Email = "owner1@example.com",
					//Role = Role.Driver,
					NormalizedUserName = "OWNER1@EXAMPLE.COM",
					NormalizedEmail = "OWNER1@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!"),
                    Balance = 1000000
                },
				new ApplicationUser
				{
					Id = "owner2",
					UserName = "owner2",
					Email = "owner2@example.com",
					//Role = Role.Driver,
					NormalizedUserName = "OWNER2@EXAMPLE.COM",
					NormalizedEmail = "OWNER2@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!"),
                    Balance = 1000000
                },
                new ApplicationUser
                {
                    Id = "Admin",
                    UserName = "Admin",
                    Email = "admin@example.com",
                    //Role = Role.Admin,
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123!"),
                    Balance = 10
                }
            };
			modelBuilder.Entity<ApplicationUser>().HasData(users);
			
            // Seed UserRoles (assign users to roles)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "user1", RoleId = userRoleId }, 
                new IdentityUserRole<string> { UserId = "user2", RoleId = userRoleId }, 
                new IdentityUserRole<string> { UserId = "owner1", RoleId = driverRoleId }, 
                new IdentityUserRole<string> { UserId = "owner2", RoleId = driverRoleId },
                new IdentityUserRole<string> { UserId = "Admin", RoleId = adminRoleId } 
            );

			var drivers = new List<Driver> {
				new Driver {
					UserID = "owner1",
					LicenseNumber = "59-V1 793.79",
					LicenseExpiryDate = new DateTime(2024, 1, 3),
					LicenseImageUrl = "/images/Licenses/license.jpg",
					NationalIdUrl = "/images/NationalID/NationalID.jpg",
                    Status = DriverStatus.Approved
				},
                new Driver {
                    UserID = "owner2",
                    LicenseNumber = "DX-012321",
                    LicenseExpiryDate = new DateTime(2024, 1, 3),
                    LicenseImageUrl = "/images/Licenses/license.jpg",
                    NationalIdUrl = "/images/NationalID/NationalID.jpg",
                    Status = DriverStatus.Approved
                }
            };
			modelBuilder.Entity<Driver>().HasData(drivers);


            // Seed RentalVehicle entities
            modelBuilder.Entity<Vehicle>().HasData(
				new Vehicle {
					RentalVehicleID = 1,
					LicensePlate = "ABC1234",
					Brand = "Toyota",
					Model = "Corolla",
					ManuYear = new DateTime(2018, 5, 1),
					NumberOfSeats = 5,
					Description = "Compact sedan, well-maintained, perfect for city driving.",
					RentalFeePerDay = 25.0f,
					RentalFeePerKilo = 4.0f,
					OwnerId = "user1", // Assuming ApplicationUser with ID user123 exists
					ThumbnailUrl = "/images/Thumbnail/ToyotaCorolla.jpg",
					Location = "Quan 1, TP HCM",
					FuelType = FuelType.Petrol,
                    Transmission = Transmission.Automatic,
					FuelConsumption = 8
                },
				new Vehicle {
					RentalVehicleID = 2,
					LicensePlate = "XYZ5678",
					Brand = "Ford",
					Model = "Focus",
					ManuYear = new DateTime(2020, 7, 15),
					NumberOfSeats = 5,
					Description = "Spacious hatchback, ideal for city drives and family trips.",
					RentalFeePerDay = 30.0f,
					RentalFeePerKilo = 5.0f,
					OwnerId = "user1", // Assuming ApplicationUser with ID user124 exists
					ThumbnailUrl = "/images/Thumbnail/FordFocus.jpg",
                    Location = "Quan 2, TP HCM",
                    FuelType = FuelType.Petrol,
                    Transmission = Transmission.Automatic,
                    FuelConsumption = 9
                },
				new Vehicle {
					RentalVehicleID = 3,
					LicensePlate = "LMN7890",
					Brand = "BMW",
					Model = "X5",
					ManuYear = new DateTime(2022, 3, 10),
					NumberOfSeats = 7,
					Description = "Luxury SUV with premium features, perfect for long road trips.",
					RentalFeePerDay = 95.0f,
					RentalFeePerKilo = 15.0f,
					OwnerId = "user1",
					ThumbnailUrl = "/images/Thumbnail/BMWx5.png",
                    Location = "Quan 3, TP HCM",
                    FuelType = FuelType.Diesel,
                    Transmission = Transmission.Automatic,
                    FuelConsumption = 10
                },
				new Vehicle {
					RentalVehicleID = 4,
					LicensePlate = "OPQ1122",
					Brand = "Honda",
					Model = "Civic",
					ManuYear = new DateTime(2019, 6, 5),
					NumberOfSeats = 5,
					Description = "Economical sedan, perfect for daily use and city driving.",
					RentalFeePerDay = 22.0f,
					RentalFeePerKilo = 4.0f,
					OwnerId = "user2",
					ThumbnailUrl = "/images/Thumbnail/HondaCivic.png",
                    Location = "Quan 4, TP HCM",
                    FuelType = FuelType.Petrol,
                    Transmission = Transmission.Automatic,
                    FuelConsumption = 11
                },
				new Vehicle {
					RentalVehicleID = 5,
					LicensePlate = "RST9876",
					Brand = "Mercedes",
					Model = "E-Class",
					ManuYear = new DateTime(2021, 11, 20),
					NumberOfSeats = 5,
					Description = "High-end luxury sedan with modern technology and comfort features.",
					RentalFeePerDay = 150.0f,
					RentalFeePerKilo = 20.0f,
					OwnerId = "user2",
					ThumbnailUrl = "/images/Thumbnail/MercedesEclass.png",
                    Location = "Quan 4, TP HCM",
                    FuelType = FuelType.Petrol,
                    Transmission = Transmission.Automatic,
                    FuelConsumption = 8
                },
				new Vehicle {
					RentalVehicleID = 6,
					LicensePlate = "UVW6543",
					Brand = "Chevrolet",
					Model = "Tahoe",
					ManuYear = new DateTime(2023, 5, 10),
					NumberOfSeats = 8,
					Description = "Spacious full-size SUV, great for large families or group trips.",
					RentalFeePerDay = 85.0f,
					RentalFeePerKilo = 12.0f,
					OwnerId = "owner1",
					ThumbnailUrl = "/images/Thumbnail/ChervroletTahoe.png",
                    Location = "Quan 4, TP HCM",
                    FuelType = FuelType.Petrol,
                    Transmission = Transmission.Automatic,
                    FuelConsumption = 10
                }
			);


			// Seed CarImage entities (set foreign key explicitly)
			modelBuilder.Entity<CarImage>().HasData(
				new CarImage { CarImageID = "1", RentalVehicleID = 1, ImageUrl = "/images/Gallery/ToyotaCorolla_1.png" },
				new CarImage { CarImageID = "2", RentalVehicleID = 1, ImageUrl = "/images/Gallery/ToyotaCorolla_2.png" },
				new CarImage { CarImageID = "3", RentalVehicleID = 1, ImageUrl = "/images/Gallery/ToyotaCorolla_3.jpg" },

				new CarImage { CarImageID = "4", RentalVehicleID = 2, ImageUrl = "/images/Gallery/FordFocus_1.jpg" },
				new CarImage { CarImageID = "5", RentalVehicleID = 2, ImageUrl = "/images/Gallery/FordFocus_2.jpg" },

				new CarImage { CarImageID = "6", RentalVehicleID = 3, ImageUrl = "/images/Gallery/BMWx5_1.jpg" },
				new CarImage { CarImageID = "7", RentalVehicleID = 3, ImageUrl = "/images/Gallery/BMWx5_2.jpg" },
				
				new CarImage { CarImageID = "8", RentalVehicleID = 4, ImageUrl = "/images/Gallery/HondaCivic_1.jpg" },
				new CarImage { CarImageID = "9", RentalVehicleID = 4, ImageUrl = "/images/Gallery/HondaCivic_2.jpg" },

				new CarImage { CarImageID = "10", RentalVehicleID = 5, ImageUrl = "/images/Gallery/MercedesEclass_1.jpg" },
				new CarImage { CarImageID = "11", RentalVehicleID = 5, ImageUrl = "/images/Gallery/MercedesEclass_2.jpg" },

				new CarImage { CarImageID = "12", RentalVehicleID = 6, ImageUrl = "/images/Gallery/ChervroletTahoe_1.png" },
				new CarImage { CarImageID = "13", RentalVehicleID = 6, ImageUrl = "/images/Gallery/ChervroletTahoe_2.png" }
			);

			// Seed DriverRide entities
			modelBuilder.Entity<DriverRide>().HasData(
				new DriverRide
				{
					DriverRideID = 1,
					DriverID = "Owner1",
                    Status = Status.Pending,
                    DepartTime = new TimeOnly(23, 0, 0),
					DepartDate = new DateTime(2023, 1, 1),
					StartLocation = "THPT Thủ Đức",
					EndLocation = "Đại học Quốc Tế",
					Seats = 3,
					SeatLeft = 3
				},
				new DriverRide
				{
					DriverRideID = 2,
					DriverID = "Owner2",
                    Status = Status.Pending,
                    DepartTime = new TimeOnly(10, 0, 0),
					DepartDate = new DateTime(2023, 1, 1),
					StartLocation = "THPT Thủ Đức",
					EndLocation = "Đại học Quốc Tế",
					Seats = 3,
                    SeatLeft = 3
                }
			);
        }
    }
}
