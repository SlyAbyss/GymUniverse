using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.RoomViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        [StringLength(RoomNameMaxLength, MinimumLength = RoomNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(RoomDescriptionMaxLength, MinimumLength = RoomDescriptionMinLength)]
        public string Description { get; set; }

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public int LocationId { get; set; }
    }
}