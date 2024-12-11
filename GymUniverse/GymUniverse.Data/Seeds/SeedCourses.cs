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
    public class SeedCourses : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "Endurance Running",
                    Description = "Improve your stamina and running technique with Liam Speed’s endurance running session.",
                    Price = 50,
                    Schedule = new DateTime(2024, 2, 3, 9, 30, 0),
                    TrainerId = 6
                },

                new Course
                {
                    Id = 2,
                    Name = "Speed Training Bootcamp",
                    Description = "Intense speed training for athletes looking to improve their pace with Liam Speed.",
                    Price = 60,
                    Schedule = new DateTime(2024, 2, 5, 16, 45, 0),
                    TrainerId = 6
                },

                new Course
                {
                    Id = 3,
                    Name = "Functional Strength Conditioning",
                    Description = "Develop full-body strength for functional movements with Victor Kane.",
                    Price = 55,
                    Schedule = new DateTime(2024, 2, 7, 12, 15, 0),
                    TrainerId = 7
                },

                new Course
                {
                    Id = 4,
                    Name = "Creative Bodyweight Workout",
                    Description = "Unleash your creativity with Zara Quinn’s unique bodyweight workouts.",
                    Price = 45,
                    Schedule = new DateTime(2024, 2, 10, 11, 30, 0),
                    TrainerId = 8
                },

                new Course
                {
                    Id = 5,
                    Name = "Restorative Yoga Flow",
                    Description = "Gentle and calming yoga designed to restore your energy with Isabella Bennett.",
                    Price = 40,
                    Schedule = new DateTime(2024, 2, 15, 9, 30, 0),
                    TrainerId = 13
                },

                new Course
                {
                    Id = 6,
                    Name = "Mindful Meditation and Yoga",
                    Description = "Focus on mindfulness and meditation in this peaceful yoga class.",
                    Price = 45,
                    Schedule = new DateTime(2024, 2, 18, 17, 45, 0),
                    TrainerId = 13
                },

                new Course
                {
                    Id = 7,
                    Name = "Team Agility Training",
                    Description = "Team-oriented agility drills with Nathan Reed to enhance your speed and coordination.",
                    Price = 55,
                    Schedule = new DateTime(2024, 2, 21, 14, 30, 0),
                    TrainerId = 12
                },

                new Course
                {
                    Id = 8,
                    Name = "Fitness Mindfulness",
                    Description = "Integrate mindfulness into your fitness routine with Elijah Coleman’s unique approach.",
                    Price = 50,
                    Schedule = new DateTime(2024, 2, 25, 16, 0, 0),
                    TrainerId = 14
                },

                new Course
                {
                    Id = 9,
                    Name = "Strength Training for Beginners",
                    Description = "Get started with strength training using techniques taught by Jake Power.",
                    Price = 40,
                    Schedule = new DateTime(2024, 2, 2, 10, 30, 0),
                    TrainerId = 1
                },

                new Course
                {
                    Id = 10,
                    Name = "Powerlifting Fundamentals",
                    Description = "Learn the basics of powerlifting with Jake Power, focusing on technique and form.",
                    Price = 55,
                    Schedule = new DateTime(2024, 2, 8, 18, 10, 0),
                    TrainerId = 1
                },

                new Course
                {
                    Id = 11,
                    Name = "Advanced Strength Training",
                    Description = "Take your strength training to the next level with Alex Steele’s advanced program.",
                    Price = 70,
                    Schedule = new DateTime(2024, 2, 4, 7, 30, 0),
                    TrainerId = 2
                },

                new Course
                {
                    Id = 12,
                    Name = "Powerlifting Mastery",
                    Description = "Master the powerlifting lifts under the guidance of Alex Steele.",
                    Price = 65,
                    Schedule = new DateTime(2024, 2, 6, 13, 15, 0),
                    TrainerId = 2
                },

                new Course
                {
                    Id = 13,
                    Name = "Personalized Strength Training",
                    Description = "One-on-one personalized strength training sessions with Tina Lee.",
                    Price = 75,
                    Schedule = new DateTime(2024, 2, 9, 8, 45, 0),
                    TrainerId = 3
                },

                new Course
                {
                    Id = 14,
                    Name = "Planetary Power Strength",
                    Description = "Strength training sessions with Tina Lee inspired by planetary forces.",
                    Price = 60,
                    Schedule = new DateTime(2024, 2, 11, 16, 30, 0),
                    TrainerId = 3
                },

                 new Course
                 {
                     Id = 15,
                     Name = "Cardio Endurance Basics",
                     Description = "A solid foundation for cardio enthusiasts with Ryan Vega.",
                     Price = 45,
                     Schedule = new DateTime(2024, 2, 2, 14, 30, 0),
                     TrainerId = 4
                 },

                new Course
                {
                    Id = 16,
                    Name = "High-Intensity Interval Training (HIIT)",
                    Description = "Push your limits with Sophia Myers’ high-energy HIIT workout.",
                    Price = 50,
                    Schedule = new DateTime(2024, 2, 7, 16, 15, 0),
                    TrainerId = 5
                },

                 new Course
                 {
                     Id = 17,
                     Name = "Gentle Yoga Flow",
                     Description = "Focus on relaxation, stretching, and mindful breathing to calm the mind and body.",
                     Price = 40,
                     Schedule = new DateTime(2024, 2, 14, 10, 0, 0),
                     TrainerId = 9
                 },

                new Course
                {
                    Id = 18,
                    Name = "Yoga for Inner Peace",
                    Description = "This course blends yoga and meditation to help you achieve balance, mindfulness, and inner peace.",
                    Price = 45,
                    Schedule = new DateTime(2024, 2, 21, 17, 0, 0),
                    TrainerId = 9
                },

                new Course
                {
                    Id = 19,
                    Name = "Mindfulness Meditation and Yoga",
                    Description = "Focus on mindfulness and restorative yoga, perfect for improving overall well-being and finding mental clarity.",
                    Price = 50,
                    Schedule = new DateTime(2024, 2, 12, 19, 0, 0),
                    TrainerId = 10
                },

                new Course
                {
                    Id = 20,
                    Name = "Holistic Health Yoga",
                    Description = "A yoga class focusing on holistic health, combining movement, breathwork, and mindfulness to rejuvenate the body and mind.",
                    Price = 55,
                    Schedule = new DateTime(2024, 2, 19, 18, 30, 0),
                    TrainerId = 10
                },

                new Course
                {
                    Id = 21,
                    Name = "Speed and Agility Training",
                    Description = "Develop speed, agility, and coordination with drills designed to improve athletic performance.",
                    Price = 55,
                    Schedule = new DateTime(2024, 2, 16, 9, 30, 0),
                    TrainerId = 11
                },

                new Course
                {
                    Id = 22,
                    Name = "Agility Drills for Athletes",
                    Description = "Intensive agility drills aimed at boosting performance in competitive sports.",
                    Price = 60,
                    Schedule = new DateTime(2024, 2, 23, 16, 20, 0),
                    TrainerId = 11
                }
            );
        }
    }
}
