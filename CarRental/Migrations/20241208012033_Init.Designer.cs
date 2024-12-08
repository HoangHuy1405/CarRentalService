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
    [Migration("20241208012033_Init")]
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
                            ConcurrencyStamp = "910cf90d-234f-4914-9b36-421a267d7fff",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMPHcTUYUuoetGtwsvwLqE+6hvkt2+g+eHp9tCWiCjnaWSvnBljbHu3LTMvhDlm45w==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "6421c616-4182-40a8-a035-e21638abf40c",
                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {
                            Id = "user2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ef750d87-188a-47ff-88ce-2b28d9c615a0",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJdeZOH64JR/4NA2VvVmReTgywkv+/KbK/KioXGN299n6/qXk1fRaBC/CKGcRQ2M9A==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "681ba3b1-e46f-42aa-ab0c-f12e36cce1f4",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        },
                        new
                        {
                            Id = "owner1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2586ce8-f0fa-4a1b-a9dd-1c7b746cc968",
                            Email = "owner1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER1@EXAMPLE.COM",
                            NormalizedUserName = "OWNER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEwoeSZBbiKz9oFAIEPR6gSQmqMOLsLbESBBrWBLPNjThuiHt+G3ZWQvsXIjsfSYmw==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "6d91f461-dfa4-4765-9a30-58c028175cd3",
                            TwoFactorEnabled = false,
                            UserName = "owner1@example.com"
                        },
                        new
                        {
                            Id = "owner2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ed7e933e-0cfe-4501-92a7-8d47ccf15090",
                            Email = "owner2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER2@EXAMPLE.COM",
                            NormalizedUserName = "OWNER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAwrCOVvRUGnyyAzJT05xZ/oz/QvUMKVSwISbxX7Si2SnM8pU/cOfOxlknfSEYafOw==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "7722738c-0e21-4d94-a1c8-bda5bd4a012c",
                            TwoFactorEnabled = false,
                            UserName = "owner2@example.com"
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

                    b.HasData(
                        new
                        {
                            RentalId = 1,
                            EndDate = new DateTime(2024, 12, 10, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5887),
                            RentalVehicleID = 1,
                            StartDate = new DateTime(2024, 12, 5, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5878),
                            Status = 1,
                            UserID = "user1"
                        },
                        new
                        {
                            RentalId = 2,
                            EndDate = new DateTime(2024, 12, 12, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5892),
                            RentalVehicleID = 2,
                            StartDate = new DateTime(2024, 12, 7, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5891),
                            Status = 0,
                            UserID = "user2"
                        },
                        new
                        {
                            RentalId = 3,
                            EndDate = new DateTime(2024, 12, 13, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5895),
                            RentalVehicleID = 3,
                            StartDate = new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5894),
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            TimeCreated = new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4469),
                            imageUrl = "https://via.placeholder.com/150"
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
                            TimeCreated = new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4486),
                            imageUrl = "https://via.placeholder.com/150"
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
                            TimeCreated = new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4489),
                            imageUrl = "https://via.placeholder.com/150"
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
#pragma warning restore 612, 618
        }
    }
}
