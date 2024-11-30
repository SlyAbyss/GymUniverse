using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Room class that represents a Room in a Location.
    /// </summary>
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(RoomNameMaxLength, MinimumLength = RoomNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(RoomDescriptionMaxLength, MinimumLength = RoomDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}
