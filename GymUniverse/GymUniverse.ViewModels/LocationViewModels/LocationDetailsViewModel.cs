using GymUniverse.ViewModels.RoomViewModels;
using GymUniverse.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.ViewModels.LocationViewModels
{
    public class LocationDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
        public List<TrainerViewModel> Trainers { get; set; } = new List<TrainerViewModel>();
    }
}
