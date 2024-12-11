using GymUniverse.Data.Migrations;
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
    public class SeedEquipment : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData(
                new Equipment
                {
                    Id = 1,
                    Name = "Dumbbell",
                    Description = "For strength training exercises, perfect for building muscle mass and toning.",
                    ImageUrl = "/images/Dumbbell.png"
                },
                new Equipment
                {
                    Id = 2,
                    Name = "Kettlebell",
                    Description = "A versatile weight for dynamic strength and conditioning exercises.",
                    ImageUrl = "/images/Kettlebell.png"
                },
                new Equipment
                {
                    Id = 3,
                    Name = "Bench Press",
                    Description = "Ideal for chest and upper body strength training exercises.",
                    ImageUrl = "/images/BenchPress.png"
                },
                new Equipment
                {
                    Id = 4,
                    Name = "Treadmill",
                    Description = "Perfect for cardio workouts, jogging, and walking exercises.",
                    ImageUrl = "/images/Treadmill.png"
                },
                new Equipment
                {
                    Id = 5,
                    Name = "Battle Ropes",
                    Description = "For high-intensity functional training and conditioning.",
                    ImageUrl = "/images/BattleRopes.png"
                },
                new Equipment
                {
                    Id = 6,
                    Name = "Medicine Ball",
                    Description = "For explosive strength training, core work, and plyometric exercises.",
                    ImageUrl = "/images/MedicineBall.png"
                },
                new Equipment
                {
                    Id = 7,
                    Name = "Spin Bike",
                    Description = "For indoor cycling workouts focused on endurance and cardiovascular fitness.",
                    ImageUrl = "/images/SpinBike.png"
                },
                new Equipment
                {
                    Id = 8,
                    Name = "Rowing Machine",
                    Description = "For full-body workouts, improving strength and cardio endurance.",
                    ImageUrl = "/images/RowingMachine.png"
                },
                new Equipment
                {
                    Id = 9,
                    Name = "Resistance Bands",
                    Description = "For strength training and flexibility exercises, perfect for a variety of fitness levels.",
                    ImageUrl = "/images/ResistanceBands.png"
                },
                new Equipment
                {
                    Id = 10,
                    Name = "TRX",
                    Description = "Suspension training equipment for strength, balance, flexibility, and core stability.",
                    ImageUrl = "/images/TRX.png"
                },
                new Equipment
                {
                    Id = 11,
                    Name = "BOSU Ball",
                    Description = "A tool for balance training, stability exercises, and core workouts.",
                    ImageUrl = "/images/BOSUBall.png"
                },
                new Equipment
                {
                    Id = 12,
                    Name = "Balance Board",
                    Description = "For improving balance and coordination.",
                    ImageUrl = "/images/BalanceBoard.png"
                },
                new Equipment
                {
                    Id = 13,
                    Name = "Climbing Rope",
                    Description = "For strength training and endurance, especially for upper body and core.",
                    ImageUrl = "/images/ClimbingRope.png"
                },
                new Equipment
                {
                    Id = 14,
                    Name = "Resistance Machine",
                    Description = "For controlled strength training targeting specific muscle groups.",
                    ImageUrl = "/images/ResistanceMachine.png"
                },
                new Equipment
                {
                    Id = 15,
                    Name = "Yoga Mat",
                    Description = "A soft mat for yoga sessions, providing comfort and stability during floor exercises and poses.",
                    ImageUrl = "/images/YogaMat.png"
                },
                new Equipment
                {
                    Id = 16,
                    Name = "Barbell",
                    Description = "A heavy metal bar used for weightlifting exercises, perfect for squats, bench presses, and deadlifts.",
                    ImageUrl = "/images/Barbell.png"
                },
                new Equipment
                {
                    Id = 17,
                    Name = "Punching Bag",
                    Description = "A versatile training tool used for functional workouts, strength, and endurance training.",
                    ImageUrl = "/images/PunchingBag.png"
                }
            );          
        }
    }
}
