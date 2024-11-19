using System.ComponentModel.DataAnnotations;

namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Course class that represents a Course that is being tought by a Trainer.
    /// </summary>
    public class Course
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public  TimeOnly CourseLength { get; set; }

        [Required]
        public Trainer Trainer { get; set; } = null!;
    }
}
