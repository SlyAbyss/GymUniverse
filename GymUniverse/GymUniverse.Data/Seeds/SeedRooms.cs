using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymUniverse.Data.Seeds
{
    public class SeedRooms : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room
                {
                    Id = 1,
                    Name = "Heavy Lifting Zone",
                    Description = "A room designed for weightlifting and powerlifting, equipped with squat racks, benches, and Olympic bars.",
                    ImageUrl = "/images/HeavyLiftingZone.png",
                    LocationId = 1
                },
                new Room
                {
                    Id = 2,
                    Name = "Strength Training Hub",
                    Description = "Focus on resistance training with dumbbells, kettlebells, and cable machines.",
                    ImageUrl = "/images/StrengthTrainingHub.png",
                    LocationId = 1
                },

                new Room
                {
                    Id = 3,
                    Name = "Zumba Studio",
                    Description = "A vibrant studio for Zumba classes, complete with a sound system and energetic walls.",
                    ImageUrl = "/images/ZumbaStudio.png",
                    LocationId = 2
                },
                new Room
                {
                    Id = 4,
                    Name = "HIIT Training Arena",
                    Description = "Designed for High-Intensity Interval Training, equipped with battle ropes, boxes, and medicine balls.",
                    ImageUrl = "/images/HIITTrainingArena.png",
                    LocationId = 2
                },
                new Room
                {
                    Id = 5,
                    Name = "Spin Studio",
                    Description = "A dedicated area for spinning classes with stationary bikes and motivational lighting.",
                    ImageUrl = "/images/SpinStudio.png",
                    LocationId = 2
                },

                new Room
                {
                    Id = 6,
                    Name = "Cardio Deck",
                    Description = "A luxurious space with treadmills, elliptical machines, and stationary bikes, offering a view of the city skyline.",
                    ImageUrl = "/images/CardioDeck.png",
                    LocationId = 3
                },
                new Room
                {
                    Id = 7,
                    Name = "Private Training Suite",
                    Description = "An exclusive room for one-on-one personal training sessions, equipped with versatile fitness equipment.",
                    ImageUrl = "/images/PrivateTrainingSuite.png",
                    LocationId = 3
                },

                new Room
                {
                    Id = 8,
                    Name = "Beachfront Yoga Space",
                    Description = "A serene room for yoga and meditation with large windows showcasing the beach view.",
                    ImageUrl = "/images/BeachfrontYogaSpace.png",
                    LocationId = 4
                },
                new Room
                {
                    Id = 9,
                    Name = "Outdoor Training Zone",
                    Description = "An outdoor area designed for functional fitness training with fresh air and ocean breeze.",
                    ImageUrl = "/images/OutdoorTrainingZone.png",
                    LocationId = 4
                },

                new Room
                {
                    Id = 10,
                    Name = "Functional Training Space",
                    Description = "A dynamic area for cross-fit and functional workouts, including TRX, kettlebells, and climbing ropes.",
                    ImageUrl = "/images/FunctionalTrainingSpace.png",
                    LocationId = 5
                },
                new Room
                {
                    Id = 11,
                    Name = "Cardio Studio",
                    Description = "A space for cardio workouts with treadmills, bikes, and rowing machines in an urban-inspired setting.",
                    ImageUrl = "/images/CardioStudio.png",
                    LocationId = 5
                },

                new Room
                {
                    Id = 12,
                    Name = "Meditation Room",
                    Description = "A tranquil space for guided meditation and mindfulness practice, with ambient lighting and relaxing music.",
                    ImageUrl = "/images/MeditationRoom.png",
                    LocationId = 6
                },
                new Room
                {
                    Id = 13,
                    Name = "Pilates Studio",
                    Description = "A room for pilates sessions, equipped with reformers, mats, and resistance bands.",
                    ImageUrl = "/images/PilatesStudio.png",
                    LocationId = 6
                },
                new Room
                {
                    Id = 14,
                    Name = "Balance and Core Zone",
                    Description = "A space dedicated to improving balance and core strength, featuring BOSU balls, balance boards, and stability equipment.",
                    ImageUrl = "/images/BalanceandCoreZone.png",
                    LocationId = 6
                }
            );
        }
    }
}
