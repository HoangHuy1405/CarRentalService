using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class addMoreAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FuelConsumption",
                table: "RentalVehicles",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "RentalVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RentalVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "RentalVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29f04c26-79ea-4d7b-96e8-28f9c4fea3e4", "AQAAAAIAAYagAAAAEOhVDBWL3oPqVoxkBhmB0FhKTomh7VWyr+VaC0aWhiVWm6ls3fM3vwArg8OtM/3Exw==", "3e33a109-5e77-4c35-b67d-6a67b93bcbfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d415dc0-bf5c-430f-9130-7973e1f9d62a", "AQAAAAIAAYagAAAAEK4ws/MzgeoaFXVmS55ZcdRl0gOl6/fyRmKaAufaLViNmfZfL+N9WdgzfgOD0T5R3g==", "87e31649-06ab-44f8-a786-5266d29473eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a484131-fd64-4ecb-ab52-5b240a8a803c", "AQAAAAIAAYagAAAAEEyEHXXcX12q2rw4AVAmFIItv+qyIFtM/gmoLaaGsyh7NqkFqtesUmmeejwrlRcDcg==", "7d5d2e1c-b0ae-4683-ba54-60aaafb7921c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a87d213-e9e5-4385-8c1b-89716e272b6b", "AQAAAAIAAYagAAAAED36qmZOS6CeoymG3xDR+WNEfi8zRuhanHGOuqgIw6gNphpTGzP4So2596jEpEx4NA==", "5df98ec9-1676-4c0b-8d15-4c0ba4da9be0" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 0, "Quan 1, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2377), 1 });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 0, "Quan 2, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2404), 1 });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 1, "Quan 3, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2407), 1 });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 0, "Quan 4, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2409), 1 });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 0, "Quan 4, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2413), 1 });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                columns: new[] { "FuelConsumption", "FuelType", "Location", "TimeCreated", "Transmission" },
                values: new object[] { 0f, 0, "Quan 4, TP HCM", new DateTime(2024, 12, 12, 10, 42, 38, 68, DateTimeKind.Local).AddTicks(2416), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelConsumption",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "RentalVehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9558e8-c600-4a14-8158-2746e65191d2", "AQAAAAIAAYagAAAAEFT6iJ+te75oE1TZdPOOl8BCQBgZQkmZ/tG1aDoYmbApA3NG1I4QuIdd3HHP9ZsJVQ==", "f2453559-c33c-4897-8b9d-abe83d1d79b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d937c551-3a50-4935-afd3-90b0428b6f43", "AQAAAAIAAYagAAAAEPsDRcIfv+COrOrWEBoj98onuZFoJdRwYK/+OOmx244VQbGFlP0hwkKVgGl4JQNqJQ==", "6ddde05d-a3f8-4c6d-9e07-8b8afb6811cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9611b19-12a2-469a-9e1a-460cd04330ae", "AQAAAAIAAYagAAAAECKzRmcXchLl3UTktcnRKtmP58LnNqfYxogUeSr/6Vk7Gn8zadbFf9yBuuDCfH9u8w==", "ed720db3-da22-4fa0-8f56-5d1629c850e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8d4a3ef-8bdc-4f1a-88ec-51ce1f28681c", "AQAAAAIAAYagAAAAEIj2O2nkZAWpfsnaJzL4xVh0YCZuQ2kx/w0zxmhUnTfh+mA9Ma8C+zO0hbpzDbeDuA==", "4c2587b7-e824-40dd-b0ff-af29953e80d3" });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "RentalVehicleID",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 12, 8, 23, 23, 53, 337, DateTimeKind.Local).AddTicks(6142));
        }
    }
}
