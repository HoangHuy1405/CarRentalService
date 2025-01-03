using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RentalVehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RentalFeePerDay = table.Column<float>(type: "real", nullable: false),
                    RentalFeePerKilo = table.Column<float>(type: "real", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    FuelConsumption = table.Column<float>(type: "real", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RentalVehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverRides",
                columns: table => new
                {
                    DriverRideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    DepartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    DepartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatLeft = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRides", x => x.DriverRideID);
                    table.ForeignKey(
                        name: "FK_DriverRides_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    CarImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentalVehicleID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.CarImageID);
                    table.ForeignKey(
                        name: "FK_CarImages_Vehicles_RentalVehicleID",
                        column: x => x.RentalVehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "RentalVehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RentalVehicleID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalFee = table.Column<float>(type: "real", nullable: false),
                    depositFee = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rentals_Vehicles_RentalVehicleID",
                        column: x => x.RentalVehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "RentalVehicleID");
                });

            migrationBuilder.CreateTable(
                name: "PassengerRides",
                columns: table => new
                {
                    PassengerRideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverRideID = table.Column<int>(type: "int", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    DepartTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    DepartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalFee = table.Column<float>(type: "real", nullable: false),
                    DepositFee = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerRides", x => x.PassengerRideID);
                    table.ForeignKey(
                        name: "FK_PassengerRides_AspNetUsers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PassengerRides_DriverRides_DriverRideID",
                        column: x => x.DriverRideID,
                        principalTable: "DriverRides",
                        principalColumn: "DriverRideID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    TotalFee = table.Column<float>(type: "real", nullable: false),
                    DepositFee = table.Column<float>(type: "real", nullable: false),
                    TicketDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pdfPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerRideID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_PassengerRides_PassengerRideID",
                        column: x => x.PassengerRideID,
                        principalTable: "PassengerRides",
                        principalColumn: "PassengerRideID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "395024f2-841c-4ca1-959e-b5149909cef5", null, "Driver", "DRIVER" },
                    { "87a2025d-22a8-418e-b16a-d3eafaa50d8f", null, "User", "USER" },
                    { "fcd25a4f-4dce-4853-9865-f0fd8035d697", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "Admin", 0, 10f, "ee947be2-2c11-4f7e-b177-6f6e2572f9c4", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKsXCAw7/t5YtIwehUfsdLKy0KVKbSAQqoCzD4crnpbss48y4Gy3Orhp5bkST9GX6Q==", null, false, "6ca50b4c-7da5-4c64-a936-5dd2761e58bb", false, "Admin" },
                    { "owner1", 0, 1000000f, "d7b56615-b9a8-4d44-8f02-9f1b7b123e2a", "owner1@example.com", true, false, null, "OWNER1@EXAMPLE.COM", "OWNER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPAcJbd4ldevsZYJ9pJVOw01EJOi3vnCgd7JT3lEE6sNr72bSy5LUYYLlpoS38Dfbg==", null, false, "1ea1eb5e-cea8-49f9-b62c-18f2bf961439", false, "owner1" },
                    { "owner2", 0, 1000000f, "357707e1-9d8a-416b-ac31-f3e1e4c5ff81", "owner2@example.com", true, false, null, "OWNER2@EXAMPLE.COM", "OWNER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBqj8Zshr2Lv65kPOsjIJY+8HscGe5pxro2ZHo2yi1atSw+56pju7BmjFTYC3nRF4w==", null, false, "3fa9b519-e0fa-49c5-8a5c-c289c8e0f01f", false, "owner2" },
                    { "user1", 0, 1000000f, "649a11d5-b27d-4aca-a4da-9debea20b825", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAENr1BhItY0/1DeK7zucj0WNrLmNpusc/RliFSV9tLz50dARH31V/88shhMwWbyb1gA==", null, false, "0b4176a6-00cf-49b5-a5f5-c1bfe0885106", false, "user1" },
                    { "user2", 0, 1000000f, "d64def9e-9ab4-42c4-825b-8069243fcdc2", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFlcCyZUypY8wTaSOA92XKM9WJ5uBGxHry8CRgoYGP3KqqztklRXvcZpkGQH4Bjm2Q==", null, false, "986f0034-f376-4ede-99f9-b5377962d4a9", false, "user2@example.co" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fcd25a4f-4dce-4853-9865-f0fd8035d697", "Admin" },
                    { "395024f2-841c-4ca1-959e-b5149909cef5", "owner1" },
                    { "395024f2-841c-4ca1-959e-b5149909cef5", "owner2" },
                    { "87a2025d-22a8-418e-b16a-d3eafaa50d8f", "user1" },
                    { "87a2025d-22a8-418e-b16a-d3eafaa50d8f", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "UserID", "LicenseExpiryDate", "LicenseImageUrl", "LicenseNumber", "NationalIdUrl", "Status" },
                values: new object[,]
                {
                    { "owner1", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/Licenses/license.jpg", "59-V1 793.79", "/images/NationalID/NationalID.jpg", 1 },
                    { "owner2", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/Licenses/license.jpg", "DX-012321", "/images/NationalID/NationalID.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RentalVehicleID", "Brand", "Description", "FuelConsumption", "FuelType", "LicensePlate", "Location", "ManuYear", "Model", "NumberOfSeats", "OwnerId", "RentalFeePerDay", "RentalFeePerKilo", "ThumbnailUrl", "TimeCreated", "Transmission" },
                values: new object[,]
                {
                    { 1, "Toyota", "Compact sedan, well-maintained, perfect for city driving.", 8f, 0, "ABC1234", "Quan 1, TP HCM", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corolla", 5, "user1", 25f, 4f, "/images/Thumbnail/ToyotaCorolla.jpg", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9477), 1 },
                    { 2, "Ford", "Spacious hatchback, ideal for city drives and family trips.", 9f, 0, "XYZ5678", "Quan 2, TP HCM", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Focus", 5, "user1", 30f, 5f, "/images/Thumbnail/FordFocus.jpg", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9514), 1 },
                    { 3, "BMW", "Luxury SUV with premium features, perfect for long road trips.", 10f, 1, "LMN7890", "Quan 3, TP HCM", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "X5", 7, "user1", 95f, 15f, "/images/Thumbnail/BMWx5.png", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9519), 1 },
                    { 4, "Honda", "Economical sedan, perfect for daily use and city driving.", 11f, 0, "OPQ1122", "Quan 4, TP HCM", new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civic", 5, "user2", 22f, 4f, "/images/Thumbnail/HondaCivic.png", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9523), 1 },
                    { 5, "Mercedes", "High-end luxury sedan with modern technology and comfort features.", 8f, 0, "RST9876", "Quan 4, TP HCM", new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "E-Class", 5, "user2", 150f, 20f, "/images/Thumbnail/MercedesEclass.png", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9528), 1 },
                    { 6, "Chevrolet", "Spacious full-size SUV, great for large families or group trips.", 10f, 0, "UVW6543", "Quan 4, TP HCM", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tahoe", 8, "owner1", 85f, 12f, "/images/Thumbnail/ChervroletTahoe.png", new DateTime(2025, 1, 3, 23, 17, 51, 273, DateTimeKind.Local).AddTicks(9531), 1 }
                });

            migrationBuilder.InsertData(
                table: "CarImages",
                columns: new[] { "CarImageID", "ImageUrl", "RentalVehicleID" },
                values: new object[,]
                {
                    { "1", "/images/Gallery/ToyotaCorolla_1.png", 1 },
                    { "10", "/images/Gallery/MercedesEclass_1.jpg", 5 },
                    { "11", "/images/Gallery/MercedesEclass_2.jpg", 5 },
                    { "12", "/images/Gallery/ChervroletTahoe_1.png", 6 },
                    { "13", "/images/Gallery/ChervroletTahoe_2.png", 6 },
                    { "2", "/images/Gallery/ToyotaCorolla_2.png", 1 },
                    { "3", "/images/Gallery/ToyotaCorolla_3.jpg", 1 },
                    { "4", "/images/Gallery/FordFocus_1.jpg", 2 },
                    { "5", "/images/Gallery/FordFocus_2.jpg", 2 },
                    { "6", "/images/Gallery/BMWx5_1.jpg", 3 },
                    { "7", "/images/Gallery/BMWx5_2.jpg", 3 },
                    { "8", "/images/Gallery/HondaCivic_1.jpg", 4 },
                    { "9", "/images/Gallery/HondaCivic_2.jpg", 4 }
                });

            migrationBuilder.InsertData(
                table: "DriverRides",
                columns: new[] { "DriverRideID", "DepartDate", "DepartTime", "DriverID", "EndLocation", "SeatLeft", "Seats", "StartLocation", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(23, 0, 0), "Owner1", "Đại học Quốc Tế", 3, 3, "THPT Thủ Đức", 0 },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(10, 0, 0), "Owner2", "Đại học Quốc Tế", 3, 3, "THPT Thủ Đức", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_RentalVehicleID",
                table: "CarImages",
                column: "RentalVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRides_DriverID",
                table: "DriverRides",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerRides_DriverRideID",
                table: "PassengerRides",
                column: "DriverRideID");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerRides_PassengerID",
                table: "PassengerRides",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalVehicleID",
                table: "Rentals",
                column: "RentalVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserID",
                table: "Rentals",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerRideID",
                table: "Tickets",
                column: "PassengerRideID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OwnerId",
                table: "Vehicles",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "PassengerRides");

            migrationBuilder.DropTable(
                name: "DriverRides");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
