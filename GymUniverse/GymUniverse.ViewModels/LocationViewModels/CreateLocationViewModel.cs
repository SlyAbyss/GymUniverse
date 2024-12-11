using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.LocationViewModels
{
    public class CreateLocationViewModel
    {
        [Required]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LocationDescriptionMaxLength, MinimumLength = LocationDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(LocationAddressMaxLength, MinimumLength = LocationAddressMinLength)]
        public string Address { get; set; }

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }
    }
}