using System.ComponentModel.DataAnnotations;

namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Trainer class that represents a Trainer in a Location.
    /// </summary>
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
