using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class addGalleryImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RentalVehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalVehicles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CarImage",
                columns: table => new
                {
                    CarImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentalVehicleID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImage", x => x.CarImageID);
                    table.ForeignKey(
                        name: "FK_CarImage_RentalVehicles_RentalVehicleID",
                        column: x => x.RentalVehicleID,
                        principalTable: "RentalVehicles",
                        principalColumn: "RentalVehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_RentalVehicleID",
                table: "CarImage",
                column: "RentalVehicleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImage");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RentalVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2586ce8-f0fa-4a1b-a9dd-1c7b746cc968", "AQAAAAIAAYagAAAAEEwoeSZBbiKz9oFAIEPR6gSQmqMOLsLbESBBrWBLPNjThuiHt+G3ZWQvsXIjsfSYmw==", "6d91f461-dfa4-4765-9a30-58c028175cd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed7e933e-0cfe-4501-92a7-8d47ccf15090", "AQAAAAIAAYagAAAAEAwrCOVvRUGnyyAzJT05xZ/oz/QvUMKVSwISbxX7Si2SnM8pU/cOfOxlknfSEYafOw==", "7722738c-0e21-4d94-a1c8-bda5bd4a012c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "910cf90d-234f-4914-9b36-421a267d7fff", "AQAAAAIAAYagAAAAEMPHcTUYUuoetGtwsvwLqE+6hvkt2+g+eHp9tCWiCjnaWSvnBljbHu3LTMvhDlm45w==", "6421c616-4182-40a8-a035-e21638abf40c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef750d87-188a-47ff-88ce-2b28d9c615a0", "AQAAAAIAAYagAAAAEJdeZOH64JR/4NA2VvVmReTgywkv+/KbK/KioXGN299n6/qXk1fRaBC/CKGcRQ2M9A==", "681ba3b1-e46f-42aa-ab0c-f12e36cce1f4" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                columns: new[] { "ImageUrl", "TimeCreated" },
                values: new object[] { null, new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4469) });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                columns: new[] { "ImageUrl", "TimeCreated" },
                values: new object[] { null, new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                columns: new[] { "ImageUrl", "TimeCreated" },
                values: new object[] { null, new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5887), new DateTime(2024, 12, 5, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 12, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5892), new DateTime(2024, 12, 7, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 13, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5895), new DateTime(2024, 12, 8, 8, 20, 32, 700, DateTimeKind.Local).AddTicks(5894) });
        }
    }
}
