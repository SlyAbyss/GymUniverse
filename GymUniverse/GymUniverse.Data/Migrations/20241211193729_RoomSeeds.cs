using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoomSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cb67c15-062f-4a49-ba5e-7b3e4e9fcd0b", "AQAAAAIAAYagAAAAEAYmfgsN6xHrlXGN7jlDCQaJOdvgNomphp6AXofsPdoiNplsNj+ebEeYak8GZ6e0xw==" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "ImageUrl", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "A room designed for weightlifting and powerlifting, equipped with squat racks, benches, and Olympic bars.", "/images/HeavyLiftingZone.png", 1, "Heavy Lifting Zone" },
                    { 2, "Focus on resistance training with dumbbells, kettlebells, and cable machines.", "/images/StrengthTrainingHub.png", 1, "Strength Training Hub" },
                    { 3, "A vibrant studio for Zumba classes, complete with a sound system and energetic walls.", "/images/ZumbaStudio.png", 2, "Zumba Studio" },
                    { 4, "Designed for High-Intensity Interval Training, equipped with battle ropes, boxes, and medicine balls.", "/images/HIITTrainingArena.png", 2, "HIIT Training Arena" },
                    { 5, "A dedicated area for spinning classes with stationary bikes and motivational lighting.", "/images/SpinStudio.png", 2, "Spin Studio" },
                    { 6, "A luxurious space with treadmills, elliptical machines, and stationary bikes, offering a view of the city skyline.", "/images/CardioDeck.png", 3, "Cardio Deck" },
                    { 7, "An exclusive room for one-on-one personal training sessions, equipped with versatile fitness equipment.", "/images/PrivateTrainingSuite.png", 3, "Private Training Suite" },
                    { 8, "A serene room for yoga and meditation with large windows showcasing the beach view.", "/images/BeachfrontYogaSpace.png", 4, "Beachfront Yoga Space" },
                    { 9, "An outdoor area designed for functional fitness training with fresh air and ocean breeze.", "/images/OutdoorTrainingZone.png", 4, "Outdoor Training Zone" },
                    { 10, "A dynamic area for cross-fit and functional workouts, including TRX, kettlebells, and climbing ropes.", "/images/FunctionalTrainingSpace.png", 5, "Functional Training Space" },
                    { 11, "A space for cardio workouts with treadmills, bikes, and rowing machines in an urban-inspired setting.", "/images/CardioStudio.png", 5, "Cardio Studio" },
                    { 12, "A tranquil space for guided meditation and mindfulness practice, with ambient lighting and relaxing music.", "/images/MeditationRoom.png", 6, "Meditation Room" },
                    { 13, "A room for pilates sessions, equipped with reformers, mats, and resistance bands.", "/images/PilatesStudio.png", 6, "Pilates Studio" },
                    { 14, "A space dedicated to improving balance and core strength, featuring BOSU balls, balance boards, and stability equipment.", "/images/BalanceandCoreZone.png", 6, "Balance and Core Zone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f079c1b2-1b34-426c-ad59-05b0e36f1374", "AQAAAAIAAYagAAAAEJQO6Nb88ARatuLweaSN9CvzlEw2x44DgducbkSGM57Euzez2LE6/ikxECoQBnPZ6w==" });
        }
    }
}
