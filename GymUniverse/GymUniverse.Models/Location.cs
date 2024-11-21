using System.ComponentModel.DataAnnotations;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Location class that represents an already opened facility.
    /// </summary>
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(LocationDescriptionMaxLength, MinimumLength = LocationDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(LocationAddressMaxLength, MinimumLength = LocationAddressMinLength)]
        public string Address { get; set; } = string.Empty;

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
