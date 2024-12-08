using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class updateCarImageDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImage_RentalVehicles_RentalVehicleID",
                table: "CarImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage");

            migrationBuilder.RenameTable(
                name: "CarImage",
                newName: "CarImages");

            migrationBuilder.RenameIndex(
                name: "IX_CarImage_RentalVehicleID",
                table: "CarImages",
                newName: "IX_CarImages_RentalVehicleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages",
                column: "CarImageID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_RentalVehicles_RentalVehicleID",
                table: "CarImages",
                column: "RentalVehicleID",
                principalTable: "RentalVehicles",
                principalColumn: "RentalVehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_RentalVehicles_RentalVehicleID",
                table: "CarImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages");

            migrationBuilder.RenameTable(
                name: "CarImages",
                newName: "CarImage");

            migrationBuilder.RenameIndex(
                name: "IX_CarImages_RentalVehicleID",
                table: "CarImage",
                newName: "IX_CarImage_RentalVehicleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImage",
                table: "CarImage",
                column: "CarImageID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "665f1672-64dc-4532-bda4-04b0d705e673", "AQAAAAIAAYagAAAAED7Jkbxlb0b7t+6c0U++JpawIN9UuQtnVcWLJ1nDQQzbso3oBkL3qa5knzFNbxgYdQ==", "f4ad92fe-4910-448c-9c27-5d6ad63b1068" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859d4299-23a4-49f7-b326-86a98d704240", "AQAAAAIAAYagAAAAEBG3begkDJj4QynerLOtRm7EVL/G0sTQ2UszNMG5zEh9q2PoKlv+nBdlYBdOhKrcIQ==", "c30d3fa8-a51b-4a90-bf76-05085b60aef9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ee46ca0-3055-47f1-9b10-62409982fdfb", "AQAAAAIAAYagAAAAENpaS5q1tbWZEHqbNJnrzVRgrx7Mif2q+dWLGsWQqdiQQ9CSzHVCgxRmnBvxW9f/4g==", "c6bb09da-23c5-4470-8670-6860dd0bf6d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74771f64-894e-4850-8f98-b5f121712393", "AQAAAAIAAYagAAAAELt/sXZ+Zga7dKYNxyueYqbtxub2oV9Piw7070UWd2nv3IA2Kncp3D0R4teB/bPA6g==", "07ce08a5-1c42-48a7-ae53-7422f48bdeec" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8775), new DateTime(2024, 12, 5, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8752) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 12, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8784), new DateTime(2024, 12, 7, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 13, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8789), new DateTime(2024, 12, 8, 15, 59, 8, 215, DateTimeKind.Local).AddTicks(8788) });

            migrationBuilder.AddForeignKey(
                name: "FK_CarImage_RentalVehicles_RentalVehicleID",
                table: "CarImage",
                column: "RentalVehicleID",
                principalTable: "RentalVehicles",
                principalColumn: "RentalVehicleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
