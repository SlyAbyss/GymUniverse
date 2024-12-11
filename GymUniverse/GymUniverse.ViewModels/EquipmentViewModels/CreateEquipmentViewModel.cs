using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.EquipmentViewModels
{
    public class CreateEquipmentViewModel
    {
        public int RoomId { get; set; }

        [Required]
        [StringLength(EquipmentNameMaxLength, MinimumLength = EquipmentNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(EquipmentDescriptionMaxLength, MinimumLength = EquipmentDescriptionMinLength)]
        public string Description { get; set; }

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]    
        public string? ImageUrl { get; set; }
    }
}
