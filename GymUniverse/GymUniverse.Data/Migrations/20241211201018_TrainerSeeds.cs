using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b390fd3-38de-4414-97a1-726375388804", "AQAAAAIAAYagAAAAEDVBAg5oK9M6ROnNsm0tplxEXWo8gTyQxeGv0NEHYChm45tXGjCIw+/jLWJpp4Cnqg==" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Age", "Bio", "ImageUrl", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 35, "Certified weightlifting coach specializing in strength training and powerlifting techniques.", "/images/JakePower.png", 1, "Jake Power" },
                    { 2, 34, "A seasoned weightlifting coach with a passion for cosmic-level strength and power.", "/images/AlexSteele.png", 1, "Alex Steele" },
                    { 3, 29, "Specializes in strength training and personalized fitness plans, inspired by planetary forces.", "/images/TinaLee.png", 1, "Tina Lee" },
                    { 4, 30, "Cardio fitness expert with innovative techniques for endurance and speed.", "/images/RyanVega.png", 2, "Ryan Vega" },
                    { 5, 25, "Energetic instructor focusing on high-intensity interval training.", "/images/SophiaMyers.png", 2, "Sophia Myers" },
                    { 6, 28, "Endurance athlete and expert in treadmill and bike-based cardio programs.", "/images/LiamSpeed.png", 3, "Liam Speed" },
                    { 7, 40, "Functional training specialist helping clients achieve balance and strength.", "/images/VictorKane.png", 3, "Victor Kane" },
                    { 8, 28, "Creative trainer focusing on dynamic functional workouts.", "/images/ZaraQuinn.png", 3, "Zara Quinn" },
                    { 9, 32, "Certified yoga instructor with a focus on mindfulness and inner peace.", "/images/EvelynHart.png", 4, "Evelyn Hart" },
                    { 10, 35, "Expert in yoga and wellness, dedicated to holistic health.", "/images/SamuelBrooks.png", 4, "Samuel Brooks" },
                    { 11, 30, "Multi-sport coach specializing in agility and competitive training.", "/images/KaraHayes.png", 5, "Kara Hayes" },
                    { 12, 33, "Performance coach dedicated to team dynamics and sports excellence.", "/images/NathanReed.png", 5, "Nathan Reed" },
                    { 13, 27, "Wellness coach focusing on restorative practices and meditation.", "/images/IsabellaBennett.png", 6, "Isabella Bennett" },
                    { 14, 38, "Experienced trainer integrating mindfulness into fitness routines.", "/images/ElijahColeman.png", 6, "Elijah Coleman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cb67c15-062f-4a49-ba5e-7b3e4e9fcd0b", "AQAAAAIAAYagAAAAEAYmfgsN6xHrlXGN7jlDCQaJOdvgNomphp6AXofsPdoiNplsNj+ebEeYak8GZ6e0xw==" });
        }
    }
}
