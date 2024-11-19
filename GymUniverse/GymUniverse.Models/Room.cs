using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}
