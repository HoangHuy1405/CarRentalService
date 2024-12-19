using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class addAttriRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalVehicles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpLocation",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "depositFee",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "totalFee",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e731c3d5-b4ae-4bdb-badf-d2fd87301da4", "AQAAAAIAAYagAAAAEIbArjw2M5JwofGMc+8VIdDd0YnaewSkFJPtPXe5XRhO3O3NDdIBOxe8i248pX3TUA==", "bcb8eaba-dedd-4136-8eac-361446295d07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9eefdc4-3e1a-4455-9bd9-6c6aeeb57fd4", "AQAAAAIAAYagAAAAEF7wAn60oG9i9XeIqdPxebfrVk5+exxZbForWm1zNOWvdde83RZtuGFSwKq3k+gyMA==", "7743099d-bc17-4580-9fe3-8ad044473c7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01551f33-b5c3-49e6-8df2-ce5111fac048", "AQAAAAIAAYagAAAAEHZIiFCDLewZ8bGz7LeseJoJiCpi8K3pPR7/dgxrBoIkPUBz8zVAs6JGq6TtyE6f2Q==", "30f27601-10f4-4210-9a43-37777a5840b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aba1c6d4-4cfa-475a-9fc0-eb93f2dedab1", "AQAAAAIAAYagAAAAELDtAth+XgIyDtGKkfVyK4cA9qZlBYAFvCtvcEsTXFAcD8HCsohY6415H9CSmWIT2Q==", "23f0a9fb-9bfd-4589-866d-a8a6c95c560a" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 17, 23, 0, 22, 299, DateTimeKind.Local).AddTicks(8535));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpLocation",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "depositFee",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "totalFee",
                table: "Rentals");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalVehicles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bf75ef7-ede8-41e8-8d6d-069a035b6acd", "AQAAAAIAAYagAAAAEMH5c8agLmPKOUD6QqcC0H821xIu9ZAioqewvs+MZU3AzgkxTuGyQ8rZuyMVPBTkdQ==", "0e780a9e-c7fb-41b0-8d37-8308d17d4b5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b0e6821-fb67-4159-8250-a2a4d3213b2f", "AQAAAAIAAYagAAAAEH/7U+NC2u1G6MhjnKqjF2XdknWqJ+xDor37HY7OpQ5RHC+SUuzF8VGRUJxB++awmQ==", "ba22ad17-bc9d-42a6-a4d6-06cbcaf0dead" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41f8a1cf-2202-4cc8-8658-7966cd5a214e", "AQAAAAIAAYagAAAAEMXqpRwkRy0OD5GhkbR5hk+KFPBUFLVIn4rSMGzdblxBGlwuN3eEPHFDNRe8Tcdb6Q==", "20cd2086-e686-45c2-91fc-c10d5f83e578" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9e18998-def1-49bf-ba7f-69b79789bfda", "AQAAAAIAAYagAAAAEHoXx2gxy6mAI3feLzYRp917qkcGwz/TfC4Z9fzya/Om5Sa2pcFhqgTUUKHVcEcvkw==", "0ab04037-d12d-41b3-afbe-171173b90197" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 12, 10, 50, 37, 401, DateTimeKind.Local).AddTicks(7836));
        }
    }
}
