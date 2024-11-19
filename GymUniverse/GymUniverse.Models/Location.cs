using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
