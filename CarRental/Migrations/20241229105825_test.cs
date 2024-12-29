using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b38cb7e7-da47-46f8-8efc-a1b3216603f0", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8eef332e-d30b-410e-95b6-829632c94d5f", "owner1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8eef332e-d30b-410e-95b6-829632c94d5f", "owner2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eef332e-d30b-410e-95b6-829632c94d5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38cb7e7-da47-46f8-8efc-a1b3216603f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c9df78-9646-4435-a9ee-f2b77e2eba22", null, "Driver", "DRIVER" },
                    { "9c98be9e-c69a-4f24-8bec-d32a4a01c134", null, "Admin", "ADMIN" },
                    { "c080df9b-6503-4d9a-82c0-0485c4e68d6d", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc53cba-47b6-4a42-a486-b0107e3019ca", "AQAAAAIAAYagAAAAEA27BOwavfUm2ipKhJp+pyJ46gdsbh1uz3+gYL68eHc7NzRDET+DWhoPYJrGZU14Aw==", "1d3aa02b-1b0b-4404-b647-36267216469b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17a0c757-224d-45d3-9a85-027e82415780", "AQAAAAIAAYagAAAAEASpAx5+eRE3R1XuUaEHGNU4euLP5inO4/TCH/HchSayIAOmKDJpMdARUJQiW2HbeA==", "59fe46f3-a4a1-4410-9883-f3c421a801c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "658afa52-4295-4067-a6d2-32b18c3bd57d", "AQAAAAIAAYagAAAAEHs97rTREzfmuOB9KeQYhp7VbI33pmfyLW8gH4oc8WAE7cFL6o7lAOLltuom2sNBKA==", "f8a6a262-d7fe-4b61-837a-1c987f707a70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f271513-d8bb-4d2d-988a-a7bb388a5c97", "AQAAAAIAAYagAAAAEP0fw45FU0I+cFQ5OCYrLUuXGJqWu4gWJH7/qFV811s9/MkfgI76KGqFudtVtlC91A==", "19eff326-5b5f-4c15-870e-14f5d5b7c4e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9869120f-4088-4b00-996c-731e34f32009", "AQAAAAIAAYagAAAAED2/t1AcWcs8SELYhpB6NHw5uTD8q1Q9a5ZdfVcHcailJXqIm68J7U4Z9nABJS0g9g==", "7dd0bf40-2a8b-4a63-9ce6-187347158301" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 58, 25, 229, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9c98be9e-c69a-4f24-8bec-d32a4a01c134", "Admin" },
                    { "12c9df78-9646-4435-a9ee-f2b77e2eba22", "owner1" },
                    { "12c9df78-9646-4435-a9ee-f2b77e2eba22", "owner2" },
                    { "c080df9b-6503-4d9a-82c0-0485c4e68d6d", "user1" },
                    { "c080df9b-6503-4d9a-82c0-0485c4e68d6d", "user2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c98be9e-c69a-4f24-8bec-d32a4a01c134", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12c9df78-9646-4435-a9ee-f2b77e2eba22", "owner1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12c9df78-9646-4435-a9ee-f2b77e2eba22", "owner2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c080df9b-6503-4d9a-82c0-0485c4e68d6d", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c080df9b-6503-4d9a-82c0-0485c4e68d6d", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c9df78-9646-4435-a9ee-f2b77e2eba22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c98be9e-c69a-4f24-8bec-d32a4a01c134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c080df9b-6503-4d9a-82c0-0485c4e68d6d");

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerRideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverRideID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    DepositFee = table.Column<float>(type: "real", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalFee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerRideID);
                    table.ForeignKey(
                        name: "FK_Passengers_AspNetUsers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passengers_DriverRides_DriverRideID",
                        column: x => x.DriverRideID,
                        principalTable: "DriverRides",
                        principalColumn: "DriverRideID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9", null, "User", "USER" },
                    { "8eef332e-d30b-410e-95b6-829632c94d5f", null, "Driver", "DRIVER" },
                    { "b38cb7e7-da47-46f8-8efc-a1b3216603f0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628dd775-38dc-4d63-afcb-551f4cb96f96", "AQAAAAIAAYagAAAAEBnf8Vkij2oT9QuAXT8SL4bF/NYQjR/i78ILyHlYai6f2+ODWlFFj9FUlMOSSr3G/g==", "720ff030-005c-4f16-baf6-b42cae97865f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75e1e1f4-6031-4076-a90c-cf2f9693f356", "AQAAAAIAAYagAAAAEA8jU3jcwkFf2H7APAv/N8FuCCMmIlOSdEzT99Um4lMtXYuKkneAoVZy5+mdnsf5aA==", "5e6b3545-22a7-4301-914d-a09b8af48833" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f413a35-52cd-455e-9f41-45cf8a36c54b", "AQAAAAIAAYagAAAAEKpLN/Snmqd2HgFy3d/zf29Rgo1nMDazZIddQn03cRLPVKTKFAwArfk74vi1VJliVQ==", "ebb5d70a-0ea4-4673-b596-8c6f7339b04b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68123284-fb2d-40db-a0ab-6332e5dc7c01", "AQAAAAIAAYagAAAAEJbhd2DSB+Pwdi47GldOKeJ884mzFKlvh1TAi7bjSx5IalBVW+j3ymD6Hg1je6GmEQ==", "facd7f20-4d8c-4188-990a-8c798fdc0cd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f477c76-fdaa-44b6-94fe-7fe453261146", "AQAAAAIAAYagAAAAECXmv1qL2o4xVFJQ5MFR/b7NX5yT6oHu3/K/u0saLTDsQ6hVcrh98rOm00EudAhrNA==", "c8803100-f8e5-4666-a0fb-b94e742bdac2" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 29, 17, 57, 23, 562, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b38cb7e7-da47-46f8-8efc-a1b3216603f0", "Admin" },
                    { "8eef332e-d30b-410e-95b6-829632c94d5f", "owner1" },
                    { "8eef332e-d30b-410e-95b6-829632c94d5f", "owner2" },
                    { "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9", "user1" },
                    { "8c58d9f6-3551-4f46-8681-9f4acd4b0fd9", "user2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_DriverRideID",
                table: "Passengers",
                column: "DriverRideID");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PassengerID",
                table: "Passengers",
                column: "PassengerID");
        }
    }
}
