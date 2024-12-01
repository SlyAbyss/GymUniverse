using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.ViewModels.EquipmentViewModels
{
    public class CreateEquipmentViewModel
    {
        public int RoomId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
