using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class EquipmentSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09b2f357-58a7-4dcf-85b2-517790690f54", "AQAAAAIAAYagAAAAEKUXsob1fMuJ1oV60tSvNniNfevh9saSjxar0g7Ug6i2UlYyY7LKT19x0pzvUo0N8g==" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "For strength training exercises, perfect for building muscle mass and toning.", "/images/Dumbbell.png", "Dumbbell" },
                    { 2, "A versatile weight for dynamic strength and conditioning exercises.", "/images/Kettlebell.png", "Kettlebell" },
                    { 3, "Ideal for chest and upper body strength training exercises.", "/images/BenchPress.png", "Bench Press" },
                    { 4, "Perfect for cardio workouts, jogging, and walking exercises.", "/images/Treadmill.png", "Treadmill" },
                    { 5, "For high-intensity functional training and conditioning.", "/images/BattleRopes.png", "Battle Ropes" },
                    { 6, "For explosive strength training, core work, and plyometric exercises.", "/images/MedicineBall.png", "Medicine Ball" },
                    { 7, "For indoor cycling workouts focused on endurance and cardiovascular fitness.", "/images/SpinBike.png", "Spin Bike" },
                    { 8, "For full-body workouts, improving strength and cardio endurance.", "/images/RowingMachine.png", "Rowing Machine" },
                    { 9, "For strength training and flexibility exercises, perfect for a variety of fitness levels.", "/images/ResistanceBands.png", "Resistance Bands" },
                    { 10, "Suspension training equipment for strength, balance, flexibility, and core stability.", "/images/TRX.png", "TRX" },
                    { 11, "A tool for balance training, stability exercises, and core workouts.", "/images/BOSUBall.png", "BOSU Ball" },
                    { 12, "For improving balance and coordination.", "/images/BalanceBoard.png", "Balance Board" },
                    { 13, "For strength training and endurance, especially for upper body and core.", "/images/ClimbingRope.png", "Climbing Rope" },
                    { 14, "For controlled strength training targeting specific muscle groups.", "/images/ResistanceMachine.png", "Resistance Machine" },
                    { 15, "A soft mat for yoga sessions, providing comfort and stability during floor exercises and poses.", "/images/YogaMat.png", "Yoga Mat" },
                    { 16, "A heavy metal bar used for weightlifting exercises, perfect for squats, bench presses, and deadlifts.", "/images/Barbell.png", "Barbell" },
                    { 17, "A versatile training tool used for functional workouts, strength, and endurance training.", "/images/PunchingBag.png", "Punching Bag" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f1e5897-f544-489b-9b76-621532f74ffc", "AQAAAAIAAYagAAAAEOnRXNC7V2py9ZdsEvzAXGX5mI9TOeS/FAYDXRDNuTUFEQhUmH6mWfnADvfbcbxt8w==" });
        }
    }
}
