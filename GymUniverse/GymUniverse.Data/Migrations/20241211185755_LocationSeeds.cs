using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class LocationSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f079c1b2-1b34-426c-ad59-05b0e36f1374", "AQAAAAIAAYagAAAAEJQO6Nb88ARatuLweaSN9CvzlEw2x44DgducbkSGM57Euzez2LE6/ikxECoQBnPZ6w==" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "371 Metal Street, Muscle City", "A premier gym with top-of-the-line equipment for bodybuilders and athletes. Offering personal training and nutrition counseling.", "/images/HeavyMetalFitness.png", "Heavy Metal Fitness" },
                    { 2, "968 Fitness Blvd, Healthtown", "Fusion of fitness and fun! Join group classes, enjoy strength training, and explore our yoga and cardio sessions.", "/images/FitFusion.png", "FitFusion" },
                    { 3, "137 Summit Drive, Peak Valley", "A luxurious gym offering top-notch services with an exclusive members-only fitness experience. From cardio to weight training, we have it all.", "/images/ThePeakFitnessCenter.png", "The Peak Fitness Center" },
                    { 4, "119 Beachfront Ave, Sunny Bay", "Work out by the beach! Enjoy outdoor workouts with a view of the ocean. Perfect for yoga, pilates, and beach-inspired fitness.", "/images/SouthBeachFitness.png", "South Beach Fitness" },
                    { 5, "247 Street Way, City Centre", "Modern gym with a focus on functional training, cross-fit, and cardio. Open 24/7 to cater to your busy urban lifestyle.", "/images/UrbanFitGym.png", "Urban Fit Gym" },
                    { 6, "727 Wellness Lane, Tranquil Park", "Find your balance at ZenFit! We offer a range of holistic fitness programs including yoga, pilates, and meditation, along with strength training.", "/images/ZenFitWellness.png", "ZenFit Wellness" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b897000-ad23-471f-832e-5a41f60b15b0", "AQAAAAIAAYagAAAAEC8zEfs2ybDBd91pYiB3mcwKlbGpMsUrb50NFFOBy7u1BqpIUCvMp6/k9kiaqZ5nyw==" });
        }
    }
}
