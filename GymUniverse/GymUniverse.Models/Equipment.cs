using System.ComponentModel.DataAnnotations;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Equipment class that represents an Equipment that is being used in a Room.
    /// </summary>
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EquipmentNameMaxLength,MinimumLength = EquipmentNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(EquipmentDescriptionMaxLength,MinimumLength = EquipmentDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [StringLength(UrlMaxLength,MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public ICollection<RoomEquipment> RoomEquipments { get; set; }
    }
}
