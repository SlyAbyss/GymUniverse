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
    public class SeedEqupmentRoomRelation : IEntityTypeConfiguration<RoomEquipment>
    {
        public void Configure(EntityTypeBuilder<RoomEquipment> builder)
        {
            builder.HasData(
                    new RoomEquipment { EquipmentId = 1, RoomId = 2 },
                    new RoomEquipment { EquipmentId = 1, RoomId = 10 },
                    new RoomEquipment { EquipmentId = 2, RoomId = 2 },
                    new RoomEquipment { EquipmentId = 2, RoomId = 10 },
                    new RoomEquipment { EquipmentId = 2, RoomId = 4 },
                    new RoomEquipment { EquipmentId = 3, RoomId = 1 },
                    new RoomEquipment { EquipmentId = 4, RoomId = 6 },
                    new RoomEquipment { EquipmentId = 4, RoomId = 11 },
                    new RoomEquipment { EquipmentId = 5, RoomId = 4 },
                    new RoomEquipment { EquipmentId = 6, RoomId = 4 },
                    new RoomEquipment { EquipmentId = 7, RoomId = 5 },
                    new RoomEquipment { EquipmentId = 8, RoomId = 11 },
                    new RoomEquipment { EquipmentId = 9, RoomId = 13 },
                    new RoomEquipment { EquipmentId = 9, RoomId = 12 },
                    new RoomEquipment { EquipmentId = 10, RoomId = 10 },
                    new RoomEquipment { EquipmentId = 11, RoomId = 14 },
                    new RoomEquipment { EquipmentId = 12, RoomId = 14 },
                    new RoomEquipment { EquipmentId = 13, RoomId = 10 },
                    new RoomEquipment { EquipmentId = 14, RoomId = 2 },
                    new RoomEquipment { EquipmentId = 15, RoomId = 8 },
                    new RoomEquipment { EquipmentId = 15, RoomId = 12 },
                    new RoomEquipment { EquipmentId = 15, RoomId = 13 },
                    new RoomEquipment { EquipmentId = 16, RoomId = 1 },
                    new RoomEquipment { EquipmentId = 16, RoomId = 2 },
                    new RoomEquipment { EquipmentId = 17, RoomId = 4 },
                    new RoomEquipment { EquipmentId = 17, RoomId = 10 },
                    new RoomEquipment { EquipmentId = 17, RoomId = 13 });
        }
    }
}
