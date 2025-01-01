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
                    SeatLeft = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33f12208-8802-419a-ba33-ae49b3901331", null, "Admin", "ADMIN" },
                    { "581d15d6-a327-43a5-bc7b-5eb3f7ccafaa", null, "Driver", "DRIVER" },
                    { "64d69f31-19f7-4ed1-adc0-778dbe0662c0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "Admin", 0, "df8b92d6-a22c-41f7-8453-5dc053b15488", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDaxh48Yg+5kv2eDCXD0p2yuk5ErraElvjLoMZj0PMB7xmoUk+NgkVmAfLwcnjYxDw==", null, false, "2d475ca5-996d-421e-9dd9-abc8aad2d511", false, "Admin" },
                    { "owner1", 0, "b92a234e-06ce-4cb3-99ba-4ad3850ec50f", "owner1@example.com", true, false, null, "OWNER1@EXAMPLE.COM", "OWNER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEC+unMN59Pu3I/oCDDi7agfVOrAcxIL/GKiXKB9Y+xC4lRJ1so+OCw/wIkY2NvFqxw==", null, false, "8e9227ef-c34f-43d1-8f93-fb98e00a98c8", false, "owner1" },
                    { "owner2", 0, "57bf14b6-7807-44ee-8065-181d2a6a4b28", "owner2@example.com", true, false, null, "OWNER2@EXAMPLE.COM", "OWNER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF0sSjmQCYMkDYplzi4W157G+t/MvWBW7mV50TOOZ80OhsQZtQSe58zkdmw/jOBbbQ==", null, false, "182f12fb-48c6-4e7a-a31e-8feb2d070a42", false, "owner2" },
                    { "user1", 0, "f1e83dc1-9476-4aba-8db7-f29cf9ac2e43", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPLgooEtKJfGiFpu6D5h/jhjb7BFbVCQkUOEfb/OKPajL7UggRPc8PCJhR6Zo/S2Gg==", null, false, "727b38c1-99ea-40ab-838a-98e8f5336051", false, "user1" },
                    { "user2", 0, "2d5aca75-986b-470e-85a7-401c1dbe964e", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF+xIoUmMDOkZ7dAYyh/OhBMwUr9McIdHzGFadaBE/qyUPQkQoPBQTJqzZdXGBZp4w==", null, false, "ab78bd05-6829-4148-bea1-4c51ae6e1f41", false, "user2@example.co" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "33f12208-8802-419a-ba33-ae49b3901331", "Admin" },
                    { "581d15d6-a327-43a5-bc7b-5eb3f7ccafaa", "owner1" },
                    { "581d15d6-a327-43a5-bc7b-5eb3f7ccafaa", "owner2" },
                    { "64d69f31-19f7-4ed1-adc0-778dbe0662c0", "user1" },
                    { "64d69f31-19f7-4ed1-adc0-778dbe0662c0", "user2" }
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
                    { 1, "Toyota", "Compact sedan, well-maintained, perfect for city driving.", 8f, 0, "ABC1234", "Quan 1, TP HCM", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corolla", 5, "user1", 25f, 0.18f, "/images/Thumbnail/ToyotaCorolla.jpg", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(2998), 1 },
                    { 2, "Ford", "Spacious hatchback, ideal for city drives and family trips.", 9f, 0, "XYZ5678", "Quan 2, TP HCM", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Focus", 5, "user1", 30f, 0.2f, "/images/Thumbnail/FordFocus.jpg", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(3039), 1 },
                    { 3, "BMW", "Luxury SUV with premium features, perfect for long road trips.", 10f, 1, "LMN7890", "Quan 3, TP HCM", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "X5", 7, "user1", 95f, 0.5f, "/images/Thumbnail/BMWx5.png", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(3044), 1 },
                    { 4, "Honda", "Economical sedan, perfect for daily use and city driving.", 11f, 0, "OPQ1122", "Quan 4, TP HCM", new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civic", 5, "user2", 22f, 0.17f, "/images/Thumbnail/HondaCivic.png", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(3047), 1 },
                    { 5, "Mercedes", "High-end luxury sedan with modern technology and comfort features.", 8f, 0, "RST9876", "Quan 4, TP HCM", new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "E-Class", 5, "user2", 150f, 1f, "/images/Thumbnail/MercedesEclass.png", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(3050), 1 },
                    { 6, "Chevrolet", "Spacious full-size SUV, great for large families or group trips.", 10f, 0, "UVW6543", "Quan 4, TP HCM", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tahoe", 8, "owner1", 85f, 0.6f, "/images/Thumbnail/ChervroletTahoe.png", new DateTime(2025, 1, 1, 10, 49, 38, 550, DateTimeKind.Local).AddTicks(3054), 1 }
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
                name: "PassengerRides");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DriverRides");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
