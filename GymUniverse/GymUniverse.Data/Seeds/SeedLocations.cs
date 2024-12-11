using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.Data.Seeds
{
    public class SeedLocations : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasData(
                new Location
                {
                    Id = 1,
                    Name = "Heavy Metal Fitness",
                    Address = "371 Metal Street, Muscle City",
                    Description = "A premier gym with top-of-the-line equipment for bodybuilders and athletes. Offering personal training and nutrition counseling.",
                    ImageUrl = "/images/HeavyMetalFitness.png"
                },
                new Location
                {
                    Id = 2,
                    Name = "FitFusion",
                    Address = "968 Fitness Blvd, Healthtown",
                    Description = "Fusion of fitness and fun! Join group classes, enjoy strength training, and explore our yoga and cardio sessions.",
                    ImageUrl = "/images/FitFusion.png"
                },
                new Location
                {
                    Id = 3,
                    Name = "The Peak Fitness Center",
                    Address = "137 Summit Drive, Peak Valley",
                    Description = "A luxurious gym offering top-notch services with an exclusive members-only fitness experience. From cardio to weight training, we have it all.",
                    ImageUrl = "/images/ThePeakFitnessCenter.png"
                },
                new Location
                {
                    Id = 4,
                    Name = "South Beach Fitness",
                    Address = "119 Beachfront Ave, Sunny Bay",
                    Description = "Work out by the beach! Enjoy outdoor workouts with a view of the ocean. Perfect for yoga, pilates, and beach-inspired fitness.",
                    ImageUrl = "/images/SouthBeachFitness.png"
                },
                new Location
                {
                    Id = 5,
                    Name = "Urban Fit Gym",
                    Address = "247 Street Way, City Centre",
                    Description = "Modern gym with a focus on functional training, cross-fit, and cardio. Open 24/7 to cater to your busy urban lifestyle.",
                    ImageUrl = "/images/UrbanFitGym.png"
                },
                new Location
                {
                    Id = 6,
                    Name = "ZenFit Wellness",
                    Address = "727 Wellness Lane, Tranquil Park",
                    Description = "Find your balance at ZenFit! We offer a range of holistic fitness programs including yoga, pilates, and meditation, along with strength training.",
                    ImageUrl = "/images/ZenFitWellness.png"
                });
        }
    }
}
