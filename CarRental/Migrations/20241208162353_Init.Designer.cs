﻿// <auto-generated />
using System;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241208162353_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "e9611b19-12a2-469a-9e1a-460cd04330ae",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECKzRmcXchLl3UTktcnRKtmP58LnNqfYxogUeSr/6Vk7Gn8zadbFf9yBuuDCfH9u8w==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "ed720db3-da22-4fa0-8f56-5d1629c850e3",
                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e8d4a3ef-8bdc-4f1a-88ec-51ce1f28681c",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIj2O2nkZAWpfsnaJzL4xVh0YCZuQ2kx/w0zxmhUnTfh+mA9Ma8C+zO0hbpzDbeDuA==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "4c2587b7-e824-40dd-b0ff-af29953e80d3",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        },
                        new
                        {
                            Id = "owner1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5f9558e8-c600-4a14-8158-2746e65191d2",
                            Email = "owner1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER1@EXAMPLE.COM",
                            NormalizedUserName = "OWNER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFT6iJ+te75oE1TZdPOOl8BCQBgZQkmZ/tG1aDoYmbApA3NG1I4QuIdd3HHP9ZsJVQ==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "f2453559-c33c-4897-8b9d-abe83d1d79b3",
                            TwoFactorEnabled = false,
                            UserName = "owner1@example.com"
                        },
                        new
                        {
                            Id = "owner2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d937c551-3a50-4935-afd3-90b0428b6f43",
                            Email = "owner2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER2@EXAMPLE.COM",
                            NormalizedUserName = "OWNER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPsDRcIfv+COrOrWEBoj98onuZFoJdRwYK/+OOmx244VQbGFlP0hwkKVgGl4JQNqJQ==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "6ddde05d-a3f8-4c6d-9e07-8b8afb6811cc",
                            TwoFactorEnabled = false,
                            UserName = "owner2@example.com"
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
                            ImageUrl = "/images/Gallery/BMWx5_1.png",
                            RentalVehicleID = 3
                        },
                        new
                        {
                            CarImageID = "7",
                            ImageUrl = "/images/Gallery/BMWx5_2.png",
                            RentalVehicleID = 3
                        },
                        new
                        {
                            CarImageID = "8",
                            ImageUrl = "/images/Gallery/HondaCivic_1.png",
                            RentalVehicleID = 4
                        },
                        new
                        {
                            CarImageID = "9",
                            ImageUrl = "/images/Gallery/HondaCivic_2.png",
                            RentalVehicleID = 4
                        },
                        new
                        {
                            CarImageID = "10",
                            ImageUrl = "/images/Gallery/MercedesEclass_1.png",
                            RentalVehicleID = 5
                        },
                        new
                        {
                            CarImageID = "11",
                            ImageUrl = "/images/Gallery/MercedesEclass_2.png",
                            RentalVehicleID = 5
                        },
                        new
                        {
                            CarImageID = "12",
                            ImageUrl = "/images/Gallery/ChervroletTahoe_1.jpg",
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

                    b.Property<int?>("RentalVehicleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RentalId");

                    b.HasIndex("RentalVehicleID");

                    b.HasIndex("UserID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRental.Models.RentalVehicle", b =>
                {
                    b.Property<int>("RentalVehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalVehicleID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LicensePlate")
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

                    b.HasKey("RentalVehicleID");

                    b.HasIndex("OwnerId");

                    b.ToTable("RentalVehicles");

                    b.HasData(
                        new
                        {
                            RentalVehicleID = 1,
                            Brand = "Toyota",
                            Description = "Compact sedan, well-maintained, perfect for city driving.",
                            LicensePlate = "ABC1234",
                            ManuYear = new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Corolla",
                            NumberOfSeats = 5,
                            OwnerId = "user1",
                            RentalFeePerDay = 25f,
                            RentalFeePerKilo = 0.18f,
                            ThumbnailUrl = "/images/Thumbnail/ToyotaCorolla.jpg",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6112)
                        },
                        new
                        {
                            RentalVehicleID = 2,
                            Brand = "Ford",
                            Description = "Spacious hatchback, ideal for city drives and family trips.",
                            LicensePlate = "XYZ5678",
                            ManuYear = new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Focus",
                            NumberOfSeats = 5,
                            OwnerId = "user1",
                            RentalFeePerDay = 30f,
                            RentalFeePerKilo = 0.2f,
                            ThumbnailUrl = "/images/Thumbnail/FordFocus.jpg",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6133)
                        },
                        new
                        {
                            RentalVehicleID = 3,
                            Brand = "BMW",
                            Description = "Luxury SUV with premium features, perfect for long road trips.",
                            LicensePlate = "LMN7890",
                            ManuYear = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "X5",
                            NumberOfSeats = 7,
                            OwnerId = "user1",
                            RentalFeePerDay = 95f,
                            RentalFeePerKilo = 0.5f,
                            ThumbnailUrl = "/images/Thumbnail/BMWx5.png",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6137)
                        },
                        new
                        {
                            RentalVehicleID = 4,
                            Brand = "Honda",
                            Description = "Economical sedan, perfect for daily use and city driving.",
                            LicensePlate = "OPQ1122",
                            ManuYear = new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Civic",
                            NumberOfSeats = 5,
                            OwnerId = "user2",
                            RentalFeePerDay = 22f,
                            RentalFeePerKilo = 0.17f,
                            ThumbnailUrl = "/images/Thumbnail/HondaCivic.png",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6138)
                        },
                        new
                        {
                            RentalVehicleID = 5,
                            Brand = "Mercedes",
                            Description = "High-end luxury sedan with modern technology and comfort features.",
                            LicensePlate = "RST9876",
                            ManuYear = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "E-Class",
                            NumberOfSeats = 5,
                            OwnerId = "user2",
                            RentalFeePerDay = 150f,
                            RentalFeePerKilo = 1f,
                            ThumbnailUrl = "/images/Thumbnail/MercedesEclass.png",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6140)
                        },
                        new
                        {
                            RentalVehicleID = 6,
                            Brand = "Chevrolet",
                            Description = "Spacious full-size SUV, great for large families or group trips.",
                            LicensePlate = "UVW6543",
                            ManuYear = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Tahoe",
                            NumberOfSeats = 8,
                            OwnerId = "owner1",
                            RentalFeePerDay = 85f,
                            RentalFeePerKilo = 0.6f,
                            ThumbnailUrl = "/images/Thumbnail/ChervroletTahoe.png",
                            TimeCreated = new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6142)
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
                    b.HasOne("CarRental.Models.RentalVehicle", "RentalVehicle")
                        .WithMany("Gallery")
                        .HasForeignKey("RentalVehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalVehicle");
                });

            modelBuilder.Entity("CarRental.Models.Rental", b =>
                {
                    b.HasOne("CarRental.Models.RentalVehicle", "RentalVehicle")
                        .WithMany()
                        .HasForeignKey("RentalVehicleID");

                    b.HasOne("CarRental.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("RentalVehicle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.RentalVehicle", b =>
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

            modelBuilder.Entity("CarRental.Models.RentalVehicle", b =>
                {
                    b.Navigation("Gallery");
                });
#pragma warning restore 612, 618
        }
    }
}
