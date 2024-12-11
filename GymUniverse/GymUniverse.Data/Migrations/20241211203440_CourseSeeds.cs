using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class CourseSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f1e5897-f544-489b-9b76-621532f74ffc", "AQAAAAIAAYagAAAAEOnRXNC7V2py9ZdsEvzAXGX5mI9TOeS/FAYDXRDNuTUFEQhUmH6mWfnADvfbcbxt8w==" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "Price", "Schedule", "TrainerId" },
                values: new object[,]
                {
                    { 1, "Improve your stamina and running technique with Liam Speed’s endurance running session.", "Endurance Running", 50, new DateTime(2024, 2, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 2, "Intense speed training for athletes looking to improve their pace with Liam Speed.", "Speed Training Bootcamp", 60, new DateTime(2024, 2, 5, 16, 45, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 3, "Develop full-body strength for functional movements with Victor Kane.", "Functional Strength Conditioning", 55, new DateTime(2024, 2, 7, 12, 15, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 4, "Unleash your creativity with Zara Quinn’s unique bodyweight workouts.", "Creative Bodyweight Workout", 45, new DateTime(2024, 2, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 5, "Gentle and calming yoga designed to restore your energy with Isabella Bennett.", "Restorative Yoga Flow", 40, new DateTime(2024, 2, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 6, "Focus on mindfulness and meditation in this peaceful yoga class.", "Mindful Meditation and Yoga", 45, new DateTime(2024, 2, 18, 17, 45, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 7, "Team-oriented agility drills with Nathan Reed to enhance your speed and coordination.", "Team Agility Training", 55, new DateTime(2024, 2, 21, 14, 30, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 8, "Integrate mindfulness into your fitness routine with Elijah Coleman’s unique approach.", "Fitness Mindfulness", 50, new DateTime(2024, 2, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 9, "Get started with strength training using techniques taught by Jake Power.", "Strength Training for Beginners", 40, new DateTime(2024, 2, 2, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "Learn the basics of powerlifting with Jake Power, focusing on technique and form.", "Powerlifting Fundamentals", 55, new DateTime(2024, 2, 8, 18, 10, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "Take your strength training to the next level with Alex Steele’s advanced program.", "Advanced Strength Training", 70, new DateTime(2024, 2, 4, 7, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, "Master the powerlifting lifts under the guidance of Alex Steele.", "Powerlifting Mastery", 65, new DateTime(2024, 2, 6, 13, 15, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "One-on-one personalized strength training sessions with Tina Lee.", "Personalized Strength Training", 75, new DateTime(2024, 2, 9, 8, 45, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, "Strength training sessions with Tina Lee inspired by planetary forces.", "Planetary Power Strength", 60, new DateTime(2024, 2, 11, 16, 30, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, "A solid foundation for cardio enthusiasts with Ryan Vega.", "Cardio Endurance Basics", 45, new DateTime(2024, 2, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 16, "Push your limits with Sophia Myers’ high-energy HIIT workout.", "High-Intensity Interval Training (HIIT)", 50, new DateTime(2024, 2, 7, 16, 15, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 17, "Focus on relaxation, stretching, and mindful breathing to calm the mind and body.", "Gentle Yoga Flow", 40, new DateTime(2024, 2, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 18, "This course blends yoga and meditation to help you achieve balance, mindfulness, and inner peace.", "Yoga for Inner Peace", 45, new DateTime(2024, 2, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 19, "Focus on mindfulness and restorative yoga, perfect for improving overall well-being and finding mental clarity.", "Mindfulness Meditation and Yoga", 50, new DateTime(2024, 2, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 20, "A yoga class focusing on holistic health, combining movement, breathwork, and mindfulness to rejuvenate the body and mind.", "Holistic Health Yoga", 55, new DateTime(2024, 2, 19, 18, 30, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 21, "Develop speed, agility, and coordination with drills designed to improve athletic performance.", "Speed and Agility Training", 55, new DateTime(2024, 2, 16, 9, 30, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 22, "Intensive agility drills aimed at boosting performance in competitive sports.", "Agility Drills for Athletes", 60, new DateTime(2024, 2, 23, 16, 20, 0, 0, DateTimeKind.Unspecified), 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b390fd3-38de-4414-97a1-726375388804", "AQAAAAIAAYagAAAAEDVBAg5oK9M6ROnNsm0tplxEXWo8gTyQxeGv0NEHYChm45tXGjCIw+/jLWJpp4Cnqg==" });
        }
    }
}
