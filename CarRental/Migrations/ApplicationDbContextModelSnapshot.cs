﻿// <auto-generated />
using System;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "user1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a875ea5a-5031-40ed-a325-b6aea29ccbcc",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBGWg3NacBGpwQ+fT5nzFxPKzgCZ8gTen4VX8DkbZ9lTTjLhwpl1VTyGnXYff/fSkw==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "6e3ab8e5-44a1-42db-84ee-50f1c9e17fd0",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "12a4553e-251e-4478-8870-3effd946ae4c",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOwDKIe8F5nmzRrUhWLLLIcbexL3i7WlWcShYL3wnwB0j2t+pFKWLLn8UyMPNxUm2w==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "16f48607-fbad-490b-b1d8-0d191d8c64b4",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.co"
                        },
                        new
                        {
                            Id = "owner1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ae4c08d4-b094-4b56-95bb-e851f058247c",
                            Email = "owner1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER1@EXAMPLE.COM",
                            NormalizedUserName = "OWNER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEC3r9QVC84LXVAgy8UEmTC2vDsvKaSSGQZbtnB5NFcP+F56+duXXv8AJmTj2xLcmmQ==",
                            PhoneNumberConfirmed = false,
                            Role = 2,
                            SecurityStamp = "c0fff88f-901f-4383-a528-c9b1f5589ee1",
                            TwoFactorEnabled = false,
                            UserName = "owner1"
                        },
                        new
                        {
                            Id = "owner2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "767e48df-eb17-442e-91d3-626f91425e73",
                            Email = "owner2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER2@EXAMPLE.COM",
                            NormalizedUserName = "OWNER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBlHfrcrkf8/EIpbEfQpqtDYchdETSJ1/TEa5WQBunR3J9NAVY+co5k3uxEQPgwJmg==",
                            PhoneNumberConfirmed = false,
                            Role = 2,
                            SecurityStamp = "c91d76ea-6d12-435b-b44b-65a8616ab65a",
                            TwoFactorEnabled = false,
                            UserName = "owner2"
                        },
                        new
                        {
                            Id = "Admin",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "596a32e4-8208-42f8-a492-a3d586a8a12a",
                            Email = "admin@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPb0UFCya5XD6lKDYphGxuB6BRNqjxGLA60fHIUnYCogAqWU6sLQVw0DsrHvsfwq1Q==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
                            SecurityStamp = "925f47e5-98d1-4c17-a236-d1545acc10f1",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("CarRental.Models.CarImage", b =>
                {
                    b.Property<string>("CarImageID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalVehicleID")
                        .HasColumnType("int");

                    b.HasKey("CarImageID");

                    b.HasIndex("RentalVehicleID");

                    b.ToTable("CarImages");

                    b.HasData(
                        new
                        {
                            CarImageID = "1",
                            ImageUrl = "/images/Gallery/ToyotaCorolla_1.png",
                            RentalVehicleID = 1
                        },
                        new
                        {
                            CarImageID = "2",
                            ImageUrl = "/images/Gallery/ToyotaCorolla_2.png",
                            RentalVehicleID = 1
                        },
                        new
                        {
                            CarImageID = "3",
                            ImageUrl = "/images/Gallery/ToyotaCorolla_3.jpg",
                            RentalVehicleID = 1
                        },
                        new
                        {
                            CarImageID = "4",
                            ImageUrl = "/images/Gallery/FordFocus_1.jpg",
                            RentalVehicleID = 2
                        },
                        new
                        {
                            CarImageID = "5",
                            ImageUrl = "/images/Gallery/FordFocus_2.jpg",
                            RentalVehicleID = 2
                        },
                        new
                        {
                            CarImageID = "6",
                            ImageUrl = "/images/Gallery/BMWx5_1.jpg",
                            RentalVehicleID = 3
                        },
                        new
                        {
                            CarImageID = "7",
                            ImageUrl = "/images/Gallery/BMWx5_2.jpg",
                            RentalVehicleID = 3
                        },
                        new
                        {
                            CarImageID = "8",
                            ImageUrl = "/images/Gallery/HondaCivic_1.jpg",
                            RentalVehicleID = 4
                        },
                        new
                        {
                            CarImageID = "9",
                            ImageUrl = "/images/Gallery/HondaCivic_2.jpg",
                            RentalVehicleID = 4
                        },
                        new
                        {
                            CarImageID = "10",
                            ImageUrl = "/images/Gallery/MercedesEclass_1.jpg",
                            RentalVehicleID = 5
                        },
                        new
                        {
                            CarImageID = "11",
                            ImageUrl = "/images/Gallery/MercedesEclass_2.jpg",
                            RentalVehicleID = 5
                        },
                        new
                        {
                            CarImageID = "12",
                            ImageUrl = "/images/Gallery/ChervroletTahoe_1.png",
                            RentalVehicleID = 6
                        },
                        new
                        {
                            CarImageID = "13",
                            ImageUrl = "/images/Gallery/ChervroletTahoe_2.png",
                            RentalVehicleID = 6
                        });
                });

            modelBuilder.Entity("CarRental.Models.Rental", b =>
                {
                    b.Property<int?>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RentalId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickUpLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RentalVehicleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("depositFee")
                        .HasColumnType("real");

                    b.Property<float>("totalFee")
                        .HasColumnType("real");

                    b.HasKey("RentalId");

                    b.HasIndex("RentalVehicleID");

                    b.HasIndex("UserID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRental.Models.Vehicle", b =>
                {
                    b.Property<int>("RentalVehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalVehicleID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<float>("FuelConsumption")
                        .HasColumnType("real");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ManuYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("RentalFeePerDay")
                        .HasColumnType("real");

                    b.Property<float>("RentalFeePerKilo")
                        .HasColumnType("real");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.HasKey("RentalVehicleID");

                    b.HasIndex("OwnerId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            RentalVehicleID = 1,
                            Brand = "Toyota",
                            Description = "Compact sedan, well-maintained, perfect for city driving.",
                            FuelConsumption = 8f,
                            FuelType = 0,
                            LicensePlate = "ABC1234",
                            Location = "Quan 1, TP HCM",
                            ManuYear = new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Corolla",
                            NumberOfSeats = 5,
                            OwnerId = "user1",
                            RentalFeePerDay = 25f,
                            RentalFeePerKilo = 0.18f,
                            ThumbnailUrl = "/images/Thumbnail/ToyotaCorolla.jpg",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2267),
                            Transmission = 1
                        },
                        new
                        {
                            RentalVehicleID = 2,
                            Brand = "Ford",
                            Description = "Spacious hatchback, ideal for city drives and family trips.",
                            FuelConsumption = 9f,
                            FuelType = 0,
                            LicensePlate = "XYZ5678",
                            Location = "Quan 2, TP HCM",
                            ManuYear = new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Focus",
                            NumberOfSeats = 5,
                            OwnerId = "user1",
                            RentalFeePerDay = 30f,
                            RentalFeePerKilo = 0.2f,
                            ThumbnailUrl = "/images/Thumbnail/FordFocus.jpg",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2295),
                            Transmission = 1
                        },
                        new
                        {
                            RentalVehicleID = 3,
                            Brand = "BMW",
                            Description = "Luxury SUV with premium features, perfect for long road trips.",
                            FuelConsumption = 10f,
                            FuelType = 1,
                            LicensePlate = "LMN7890",
                            Location = "Quan 3, TP HCM",
                            ManuYear = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "X5",
                            NumberOfSeats = 7,
                            OwnerId = "user1",
                            RentalFeePerDay = 95f,
                            RentalFeePerKilo = 0.5f,
                            ThumbnailUrl = "/images/Thumbnail/BMWx5.png",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2300),
                            Transmission = 1
                        },
                        new
                        {
                            RentalVehicleID = 4,
                            Brand = "Honda",
                            Description = "Economical sedan, perfect for daily use and city driving.",
                            FuelConsumption = 11f,
                            FuelType = 0,
                            LicensePlate = "OPQ1122",
                            Location = "Quan 4, TP HCM",
                            ManuYear = new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Civic",
                            NumberOfSeats = 5,
                            OwnerId = "user2",
                            RentalFeePerDay = 22f,
                            RentalFeePerKilo = 0.17f,
                            ThumbnailUrl = "/images/Thumbnail/HondaCivic.png",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2303),
                            Transmission = 1
                        },
                        new
                        {
                            RentalVehicleID = 5,
                            Brand = "Mercedes",
                            Description = "High-end luxury sedan with modern technology and comfort features.",
                            FuelConsumption = 8f,
                            FuelType = 0,
                            LicensePlate = "RST9876",
                            Location = "Quan 4, TP HCM",
                            ManuYear = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "E-Class",
                            NumberOfSeats = 5,
                            OwnerId = "user2",
                            RentalFeePerDay = 150f,
                            RentalFeePerKilo = 1f,
                            ThumbnailUrl = "/images/Thumbnail/MercedesEclass.png",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2306),
                            Transmission = 1
                        },
                        new
                        {
                            RentalVehicleID = 6,
                            Brand = "Chevrolet",
                            Description = "Spacious full-size SUV, great for large families or group trips.",
                            FuelConsumption = 10f,
                            FuelType = 0,
                            LicensePlate = "UVW6543",
                            Location = "Quan 4, TP HCM",
                            ManuYear = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Tahoe",
                            NumberOfSeats = 8,
                            OwnerId = "owner1",
                            RentalFeePerDay = 85f,
                            RentalFeePerKilo = 0.6f,
                            ThumbnailUrl = "/images/Thumbnail/ChervroletTahoe.png",
                            TimeCreated = new DateTime(2024, 12, 25, 10, 16, 51, 16, DateTimeKind.Local).AddTicks(2309),
                            Transmission = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c9e68395-911b-451c-aaac-4fbdfde58f76",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2fe64dfb-17ab-47f9-9cf3-9d33beeef3f8",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "8116ea80-9483-4077-a7a4-40b2fe76b27c",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "user1",
                            RoleId = "8116ea80-9483-4077-a7a4-40b2fe76b27c"
                        },
                        new
                        {
                            UserId = "user2",
                            RoleId = "8116ea80-9483-4077-a7a4-40b2fe76b27c"
                        },
                        new
                        {
                            UserId = "owner1",
                            RoleId = "2fe64dfb-17ab-47f9-9cf3-9d33beeef3f8"
                        },
                        new
                        {
                            UserId = "owner2",
                            RoleId = "2fe64dfb-17ab-47f9-9cf3-9d33beeef3f8"
                        },
                        new
                        {
                            UserId = "Admin",
                            RoleId = "c9e68395-911b-451c-aaac-4fbdfde58f76"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.CarImage", b =>
                {
                    b.HasOne("CarRental.Models.Vehicle", "RentalVehicle")
                        .WithMany("Gallery")
                        .HasForeignKey("RentalVehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalVehicle");
                });

            modelBuilder.Entity("CarRental.Models.Rental", b =>
                {
                    b.HasOne("CarRental.Models.Vehicle", "RentalVehicle")
                        .WithMany()
                        .HasForeignKey("RentalVehicleID");

                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("RentalVehicle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.Vehicle", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", "Owner")
                        .WithMany("RentalVehicles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarRental.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Models.ApplicationUser", b =>
                {
                    b.Navigation("RentalVehicles");
                });

            modelBuilder.Entity("CarRental.Models.Vehicle", b =>
                {
                    b.Navigation("Gallery");
                });
#pragma warning restore 612, 618
        }
    }
}
