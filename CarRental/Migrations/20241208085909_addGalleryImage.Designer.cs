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
    [Migration("20241208085909_addGalleryImage")]
    partial class addGalleryImage
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
                            ConcurrencyStamp = "4ee46ca0-3055-47f1-9b10-62409982fdfb",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENpaS5q1tbWZEHqbNJnrzVRgrx7Mif2q+dWLGsWQqdiQQ9CSzHVCgxRmnBvxW9f/4g==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "c6bb09da-23c5-4470-8670-6860dd0bf6d1",
                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "74771f64-894e-4850-8f98-b5f121712393",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELt/sXZ+Zga7dKYNxyueYqbtxub2oV9Piw7070UWd2nv3IA2Kncp3D0R4teB/bPA6g==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "07ce08a5-1c42-48a7-ae53-7422f48bdeec",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        },
                        new
                        {
                            Id = "owner1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "665f1672-64dc-4532-bda4-04b0d705e673",
                            Email = "owner1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER1@EXAMPLE.COM",
                            NormalizedUserName = "OWNER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAED7Jkbxlb0b7t+6c0U++JpawIN9UuQtnVcWLJ1nDQQzbso3oBkL3qa5knzFNbxgYdQ==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "f4ad92fe-4910-448c-9c27-5d6ad63b1068",
                            TwoFactorEnabled = false,
                            UserName = "owner1@example.com"
                        },
                        new
                        {
                            Id = "owner2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "859d4299-23a4-49f7-b326-86a98d704240",
                            Email = "owner2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER2@EXAMPLE.COM",
                            NormalizedUserName = "OWNER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBG3begkDJj4QynerLOtRm7EVL/G0sTQ2UszNMG5zEh9q2PoKlv+nBdlYBdOhKrcIQ==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "c30d3fa8-a51b-4a90-bf76-05085b60aef9",
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

                    b.ToTable("CarImage");
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

                    b.HasData(
                        new
                        {
                            RentalId = 1,
                            EndDate = new DateTime(2024, 12, 10, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8775),
                            RentalVehicleID = 1,
                            StartDate = new DateTime(2024, 12, 5, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8752),
                            Status = 1,
                            UserID = "user1"
                        },
                        new
                        {
                            RentalId = 2,
                            EndDate = new DateTime(2024, 12, 12, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8784),
                            RentalVehicleID = 2,
                            StartDate = new DateTime(2024, 12, 7, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8783),
                            Status = 0,
                            UserID = "user2"
                        },
                        new
                        {
                            RentalId = 3,
                            EndDate = new DateTime(2024, 12, 13, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8789),
                            RentalVehicleID = 3,
                            StartDate = new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8788),
                            Status = 2,
                            UserID = "user1"
                        });
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
                        .HasColumnType("REAL");

                    b.Property<float>("RentalFeePerKilo")
                        .HasColumnType("real");

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
                            Description = "Toyota 50 negiotable",
                            LicensePlate = "ABC-1234",
                            ManuYear = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Corolla",
                            NumberOfSeats = 4,
                            OwnerId = "owner1",
                            RentalFeePerDay = 712f,
                            RentalFeePerKilo = 50.5f,
                            TimeCreated = new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3170)
                        },
                        new
                        {
                            RentalVehicleID = 2,
                            Brand = "Honda",
                            Description = "For rental negiotable",
                            LicensePlate = "DL05 XY5678",
                            ManuYear = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Civic",
                            NumberOfSeats = 4,
                            OwnerId = "owner2",
                            RentalFeePerDay = 800f,
                            RentalFeePerKilo = 60f,
                            TimeCreated = new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3204)
                        },
                        new
                        {
                            RentalVehicleID = 3,
                            Brand = "Ford",
                            Description = "For rental",
                            LicensePlate = "GH78 JKL",
                            ManuYear = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Focus",
                            NumberOfSeats = 4,
                            OwnerId = "owner1",
                            RentalFeePerDay = 900.2f,
                            RentalFeePerKilo = 66.3f,
                            TimeCreated = new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3213)
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