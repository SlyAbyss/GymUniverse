using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GymUniverse.Constants.DataModelConstants;

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
        [StringLength(CourseNameMaxLength, MinimumLength = CourseNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(CourseDescriptionMaxLength, MinimumLength = CourseDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(CoursePriceMinAmount, CoursePriceMaxAmount)]
        public int Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateFormat)]
        public DateTime Schedule { get; set; }

        public int TrainerId { get; set; }

        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; } = null!;

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
