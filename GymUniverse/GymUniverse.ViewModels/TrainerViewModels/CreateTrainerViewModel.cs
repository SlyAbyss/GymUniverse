using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.TrainerViewModels
{
    public class CreateTrainerViewModel
    {
        [Required]
        [StringLength(TrainerNameMaxLength, MinimumLength = TrainerNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(TrainerAgeMinLimit, TrainerAgeMaxLimit)]
        public int Age { get; set; }

        [Required]
        [StringLength(TrainerBioMaxLength, MinimumLength = TrainerBioMinLength)]
        public string Bio { get; set; } = string.Empty;

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public int LocationId { get; set; }
    }
}
