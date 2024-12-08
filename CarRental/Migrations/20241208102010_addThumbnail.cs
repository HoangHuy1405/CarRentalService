using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class addThumbnail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "RentalVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4034464-bde5-41a9-a61a-eb49be93244d", "AQAAAAIAAYagAAAAEFDO7O8Yk+P1v21NRS72zaNm4xg0+3ycgtxCKUloJzwVxQH/yG9/7eOmmhg/8/VL1g==", "d607ae46-9940-4a2b-ae1e-42d122eaf3f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac17b11c-95fc-4be0-b7dd-650bef5ba9ad", "AQAAAAIAAYagAAAAEKM1UTOBcaO3HEFBQeRubtL2ZRN6cQCu/BLNV81r7EAmhIwgEJZMiCL7ty7dUZwKow==", "678d287e-7e20-447d-b01d-37541713730f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9427b49-bbe1-49d3-84d0-59751b3bfce8", "AQAAAAIAAYagAAAAEFxYj7vOWzKI1PEW9ZMVApRb8lpfGQvVhbjhmoWDAC0WVALsgCevBENmKhubBU4smQ==", "cd8a89b4-6ac4-4d5b-abfb-b269d8809a2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "645af4a2-2616-4ef8-bb00-7ed860e66e72", "AQAAAAIAAYagAAAAENtTtV3RwTUO41kfPhg5G6fYvO+G3FWr14XfHqHKl3Rh/TLvLPdJFnoAIILC7AZpGA==", "2f94eec5-5b45-4c4f-89e2-0bb5d2640bc5" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                columns: new[] { "ThumbnailUrl", "TimeCreated" },
                values: new object[] { "https://via.placeholder.com/150", new DateTime(2024, 12, 8, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(7606) });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                columns: new[] { "ThumbnailUrl", "TimeCreated" },
                values: new object[] { "https://via.placeholder.com/150", new DateTime(2024, 12, 8, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                columns: new[] { "ThumbnailUrl", "TimeCreated" },
                values: new object[] { "https://via.placeholder.com/150", new DateTime(2024, 12, 8, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9189), new DateTime(2024, 12, 5, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 12, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9198), new DateTime(2024, 12, 7, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9197) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 13, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9201), new DateTime(2024, 12, 8, 17, 20, 10, 107, DateTimeKind.Local).AddTicks(9201) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "RentalVehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "320b93c0-c4e4-4298-95af-694edd09009d", "AQAAAAIAAYagAAAAEBs8hJDUlTsc/R39Hc3wcu3l2Q/lmMWRNIKImiqALzLyPxn8ocmeGvXFMJI6hxnetA==", "d89051f4-14bc-4119-9598-02e70b1994de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41db7fbb-0171-4745-81a9-c15bef9fe469", "AQAAAAIAAYagAAAAEMNDxarzQrtINfAWdKB1gE17m4dlF01DaSXhphKra7SnmrJ+PHW+K1NVnnimFALgPA==", "3cf3571f-658f-4ffd-8bff-f4a6671aba80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9e02a4b-23a7-4f03-8b59-fe0803212a62", "AQAAAAIAAYagAAAAEA3WGFF6G+8hvN/FqHBECDWnHyLxeUsWoEIsStEmIoMBjpTfIBJEMPwtpiWScrnfqw==", "82325e39-ae05-4865-81fe-4b1977316d3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25cf1adf-3dfe-42fa-a267-508e18967d4e", "AQAAAAIAAYagAAAAENVclN+/ei+Qfh1H2yI9C2TVy1a//VQlv4ruRYRBVfA2vFM2tXpw78jAd1lLcdmDfw==", "c04fd669-fd72-4943-a348-64438fde8dea" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7938), new DateTime(2024, 12, 5, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 12, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7954), new DateTime(2024, 12, 7, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 13, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7958), new DateTime(2024, 12, 8, 16, 40, 30, 8, DateTimeKind.Local).AddTicks(7957) });
        }
    }
}
