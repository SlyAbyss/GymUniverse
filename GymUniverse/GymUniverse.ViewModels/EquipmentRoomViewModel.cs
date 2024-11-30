using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.ViewModels
{
    public class EquipmentRoomViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public List<Equipment> Equipment { get; set; }
        public List<int> SelectedEquipment { get; set; }
    }
}
