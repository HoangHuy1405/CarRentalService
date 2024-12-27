using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class changeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10fbc611-27e0-4921-8305-3f4a33361384");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e2e8da2e-44a3-44c2-b918-cdf129d9d142", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "547ca490-9612-422f-bb1f-ace2d90358f3", "owner1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "547ca490-9612-422f-bb1f-ace2d90358f3", "owner2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "547ca490-9612-422f-bb1f-ace2d90358f3", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "547ca490-9612-422f-bb1f-ace2d90358f3", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "547ca490-9612-422f-bb1f-ace2d90358f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e8da2e-44a3-44c2-b918-cdf129d9d142");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10fbc611-27e0-4921-8305-3f4a33361384", null, "Driver", "DRIVER" },
                    { "547ca490-9612-422f-bb1f-ace2d90358f3", null, "User", "USER" },
                    { "e2e8da2e-44a3-44c2-b918-cdf129d9d142", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c7f9f86-3c53-4589-9ad2-a59b639e5070", "AQAAAAIAAYagAAAAEHDFAqKkC9qE2sia2MphkdPbupln8ms2XN275pb6l20+cLDlzvulYLg27/g0qNB5Wg==", "a394493f-d2a3-48fd-8644-76c09b89cde1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab2ba68d-b9e7-461f-a0de-8c114cf896ab", "AQAAAAIAAYagAAAAEBLz+3iJUanUpr8rBXjYSQLErAJ5NvlVINUjjNzLhaO4yq6gXJpR8PhOELtAOvHt5Q==", "c9509f46-e8e2-4f1d-9630-a5f4b427f63d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7adc58c-85f7-485b-8711-461f38a6947c", "AQAAAAIAAYagAAAAEHbsxTZdvSTi6sRS47rKIXwaZ4Va3fqaFdowqWaVBD6ELO8Nei/0DNQkPDYjtiNI/g==", "32f75e22-7855-4425-909d-7c9288bf08d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bafedd71-e89a-42b2-bed1-3f6349e734e8", "AQAAAAIAAYagAAAAEL05hn4eZHbkUUEVyUSCUsMJv8q7CMEDMz7NwH44WyYfZhqh9WugX/iuPNmf2z7Wiw==", "18ac4c9e-a8b8-4abd-b6a8-70765c15966a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "436334a6-71ea-4285-8657-57511bcab7de", "AQAAAAIAAYagAAAAED6BiKNDhkKoD9q4jPn2vTOt1Ljsd5j3BYPTggtqJKRLUSloLU4NsU4Dowf/qkaJYw==", "769100a9-df33-46ae-9e6b-73ad0aa6c874" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 27, 17, 28, 2, 340, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e2e8da2e-44a3-44c2-b918-cdf129d9d142", "Admin" },
                    { "547ca490-9612-422f-bb1f-ace2d90358f3", "owner1" },
                    { "547ca490-9612-422f-bb1f-ace2d90358f3", "owner2" },
                    { "547ca490-9612-422f-bb1f-ace2d90358f3", "user1" },
                    { "547ca490-9612-422f-bb1f-ace2d90358f3", "user2" }
                });
        }
    }
}
