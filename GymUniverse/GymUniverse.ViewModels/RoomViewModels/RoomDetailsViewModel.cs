using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.ViewModels.RoomViewModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public List<RoomEquipmentViewModel> RoomsEquipments { get; set; }
    }
}
