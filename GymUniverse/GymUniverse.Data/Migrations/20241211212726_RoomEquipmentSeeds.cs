using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoomEquipmentSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25e10dd3-759f-4bad-aba7-f13234f1c174", "AQAAAAIAAYagAAAAEBgyN5SC5sZXUzTgNILx1TKI4EwKpiEdYrDQdVzR3UqpEOf7A7uPKJBE57++jEHRwQ==" });

            migrationBuilder.InsertData(
                table: "RoomsEquipments",
                columns: new[] { "EquipmentId", "RoomId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 16, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 14, 2 },
                    { 16, 2 },
                    { 2, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 17, 4 },
                    { 7, 5 },
                    { 4, 6 },
                    { 15, 8 },
                    { 1, 10 },
                    { 2, 10 },
                    { 10, 10 },
                    { 13, 10 },
                    { 17, 10 },
                    { 4, 11 },
                    { 8, 11 },
                    { 9, 12 },
                    { 15, 12 },
                    { 9, 13 },
                    { 15, 13 },
                    { 17, 13 },
                    { 11, 14 },
                    { 12, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 17, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 15, 8 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 17, 10 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 15, 12 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 15, 13 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 17, 13 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 11, 14 });

            migrationBuilder.DeleteData(
                table: "RoomsEquipments",
                keyColumns: new[] { "EquipmentId", "RoomId" },
                keyValues: new object[] { 12, 14 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09b2f357-58a7-4dcf-85b2-517790690f54", "AQAAAAIAAYagAAAAEKUXsob1fMuJ1oV60tSvNniNfevh9saSjxar0g7Ug6i2UlYyY7LKT19x0pzvUo0N8g==" });
        }
    }
}
