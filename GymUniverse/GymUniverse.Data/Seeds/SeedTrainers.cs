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
    public class SeedTrainers : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(
                new Trainer
                {
                    Id = 1,
                    Name = "Jake Power",
                    Age = 35,
                    Bio = "Certified weightlifting coach specializing in strength training and powerlifting techniques.",
                    ImageUrl = "/images/JakePower.png",
                    LocationId = 1
                }, 
                new Trainer
                {
                    Id = 2,
                    Name = "Alex Steele",
                    Age = 34,
                    Bio = "A seasoned weightlifting coach with a passion for cosmic-level strength and power.",
                    ImageUrl = "/images/AlexSteele.png",
                    LocationId = 1
                },
                new Trainer
                {
                    Id = 3,
                    Name = "Tina Lee",
                    Age = 29,
                    Bio = "Specializes in strength training and personalized fitness plans, inspired by planetary forces.",
                    ImageUrl = "/images/TinaLee.png",
                    LocationId = 1
                },

                new Trainer
                {
                    Id = 4,
                    Name = "Ryan Vega",
                    Age = 30,
                    Bio = "Cardio fitness expert with innovative techniques for endurance and speed.",
                    ImageUrl = "/images/RyanVega.png",
                    LocationId = 2
                },
                new Trainer
                {
                    Id = 5,
                    Name = "Sophia Myers",
                    Age = 25,
                    Bio = "Energetic instructor focusing on high-intensity interval training.",
                    ImageUrl = "/images/SophiaMyers.png",
                    LocationId = 2
                },

                new Trainer
                {
                    Id = 6,
                    Name = "Liam Speed",
                    Age = 28,
                    Bio = "Endurance athlete and expert in treadmill and bike-based cardio programs.",
                    ImageUrl = "/images/LiamSpeed.png",
                    LocationId = 3
                },
                new Trainer
                {
                    Id = 7,
                    Name = "Victor Kane",
                    Age = 40,
                    Bio = "Functional training specialist helping clients achieve balance and strength.",
                    ImageUrl = "/images/VictorKane.png",
                    LocationId = 3
                },
                new Trainer
                {
                    Id = 8,
                    Name = "Zara Quinn",
                    Age = 28,
                    Bio = "Creative trainer focusing on dynamic functional workouts.",
                    ImageUrl = "/images/ZaraQuinn.png",
                    LocationId = 3
                },

                new Trainer
                {
                    Id = 9,
                    Name = "Evelyn Hart",
                    Age = 32,
                    Bio = "Certified yoga instructor with a focus on mindfulness and inner peace.",
                    ImageUrl = "/images/EvelynHart.png",
                    LocationId = 4
                },
                new Trainer
                {
                    Id = 10,
                    Name = "Samuel Brooks",
                    Age = 35,
                    Bio = "Expert in yoga and wellness, dedicated to holistic health.",
                    ImageUrl = "/images/SamuelBrooks.png",
                    LocationId = 4
                },

                new Trainer
                {
                    Id = 11,
                    Name = "Kara Hayes",
                    Age = 30,
                    Bio = "Multi-sport coach specializing in agility and competitive training.",
                    ImageUrl = "/images/KaraHayes.png",
                    LocationId = 5
                },
                new Trainer
                {
                    Id = 12,
                    Name = "Nathan Reed",
                    Age = 33,
                    Bio = "Performance coach dedicated to team dynamics and sports excellence.",
                    ImageUrl = "/images/NathanReed.png",
                    LocationId = 5
                },

                new Trainer
                {
                    Id = 13,
                    Name = "Isabella Bennett",
                    Age = 27,
                    Bio = "Wellness coach focusing on restorative practices and meditation.",
                    ImageUrl = "/images/IsabellaBennett.png",
                    LocationId = 6
                },
                new Trainer
                {
                    Id = 14,
                    Name = "Elijah Coleman",
                    Age = 38,
                    Bio = "Experienced trainer integrating mindfulness into fitness routines.",
                    ImageUrl = "/images/ElijahColeman.png",
                    LocationId = 6
                }
            );
        }
    }
}
