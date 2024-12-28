using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class add_SeatLeft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6529678-bbe6-490a-b824-e494c1debd6f", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bb62129c-820d-450e-84ad-d17b52f5774d", "owner1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bb62129c-820d-450e-84ad-d17b52f5774d", "owner2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6529678-bbe6-490a-b824-e494c1debd6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb62129c-820d-450e-84ad-d17b52f5774d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55");

            migrationBuilder.AddColumn<int>(
                name: "SeatLeft",
                table: "DriverRides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80815402-202d-4fdd-a633-6f57094b08e0", null, "Driver", "DRIVER" },
                    { "858ad669-5739-4db3-aaa6-524ab759bf70", null, "Admin", "ADMIN" },
                    { "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29ac9cb7-f976-4fec-8cda-ff176e82f7cd", "AQAAAAIAAYagAAAAENBXnLadK4I0hGlWEMSFIcvXtdyZlvbMrDdHaYQd4uXffeh54SQ4VQgoeBE016c9KA==", "c12da361-3258-434c-9143-a31c2186646b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08d6669a-8f4a-49c4-ae91-cbb1ded9dbc3", "AQAAAAIAAYagAAAAENVXKR/UNzCX3qz4/GzmX3UB44BSwuoRdTGqggMHYl5ckYk80GJg6+U4QrJ5Qi+7Jg==", "6b556e5e-68db-416a-8d2a-a0ef033ab811" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1e0a7d5-3d35-4251-bb7c-956842cd4435", "AQAAAAIAAYagAAAAECWPvw7olZ9EVaQXY6tFCHIDP2ccXzvsaleqrGJSZW5oBKbvhKqq1S6WVwrtESvA2A==", "e86cf2b5-b9c5-4bca-9b5d-27d3797a9668" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef5c409f-e3ff-47b9-99be-18756d60c1f8", "AQAAAAIAAYagAAAAEEKBFYnlqYQcCEWT3rTKf+3KXecAEFK7xRJfBtRHLHLeKV0AHQX/pJcdCGzuOwNgIw==", "0437f8f0-c84d-47a8-a6e5-a7131ad53ce0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1e2ae48-2860-41e4-bdfa-5ae78bbcf250", "AQAAAAIAAYagAAAAEDLbLJCaRJAQexxy4Owf6xLVce6+qKV7CwJLfbK9voD1RmvvqeSO4OokpCelVSfveg==", "e3259291-bcf3-4789-91f2-daded265c8b1" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 28, 8, 50, 5, 286, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "858ad669-5739-4db3-aaa6-524ab759bf70", "Admin" },
                    { "80815402-202d-4fdd-a633-6f57094b08e0", "owner1" },
                    { "80815402-202d-4fdd-a633-6f57094b08e0", "owner2" },
                    { "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467", "user1" },
                    { "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467", "user2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "858ad669-5739-4db3-aaa6-524ab759bf70", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80815402-202d-4fdd-a633-6f57094b08e0", "owner1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80815402-202d-4fdd-a633-6f57094b08e0", "owner2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80815402-202d-4fdd-a633-6f57094b08e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "858ad669-5739-4db3-aaa6-524ab759bf70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf6cdf0d-fa3b-4aa9-ac07-6205a1bf3467");

            migrationBuilder.DropColumn(
                name: "SeatLeft",
                table: "DriverRides");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6529678-bbe6-490a-b824-e494c1debd6f", null, "Admin", "ADMIN" },
                    { "bb62129c-820d-450e-84ad-d17b52f5774d", null, "Driver", "DRIVER" },
                    { "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4e9247-0d05-4d37-857d-f3feece6150b", "AQAAAAIAAYagAAAAEPIec8r4JiCt3NTCfOHHmFmLQpwhhFPiymIFyMdsfwZ9/SLxDnqbd2C4p72Lh2KbmA==", "75057731-d958-4924-ae30-3f40ea515f8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3f10c6-fb6e-4d81-90a7-cb4fa2d83a2a", "AQAAAAIAAYagAAAAECmYpU7Q2EmS71K69NLeonB74hgE2+9oFnKtCN3Y84S+T0wfV3Zdf6bL4slOcTpOrQ==", "5bf9622b-9f29-423d-87ae-4cc2a545c38e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8349cd1-3a1c-4d49-b9cb-b6c9840b6f1d", "AQAAAAIAAYagAAAAELy5zI5oAfbpCaAkz8ygn6UCc7piYT3t16Yk9jhZvtC4rpt1vriXFgROAuoEteyxvQ==", "21d46281-cce5-4232-b353-fdbfa83ed81f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e1897c7-be06-4814-a532-47ba13dca7ce", "AQAAAAIAAYagAAAAEJWHTXTW10sbCHkdSNt064BEf77oyQudpfwTYjyHtt+LjIFcy9CwYF/fJC1skXUJ2A==", "f6468880-0df0-4595-b12e-61d297c59a01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b85fabd9-5a2a-4b34-b724-3544a661ae99", "AQAAAAIAAYagAAAAECuCkma3K/1p+aazh/NjwyU8nlqOPFrJLm/HvnW9AnTfjb0SE13Xb9VXx2okTGlMmw==", "20a794ea-1de2-4907-83ef-c632df0912ac" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 42, 46, 131, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a6529678-bbe6-490a-b824-e494c1debd6f", "Admin" },
                    { "bb62129c-820d-450e-84ad-d17b52f5774d", "owner1" },
                    { "bb62129c-820d-450e-84ad-d17b52f5774d", "owner2" },
                    { "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55", "user1" },
                    { "fb2c8ee4-a659-4556-b1a5-9e9b6c3b1e55", "user2" }
                });
        }
    }
}
