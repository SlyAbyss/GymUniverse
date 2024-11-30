using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GymUniverse.Constants.DataModelConstants;

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
        [StringLength(TrainerNameMaxLength, MinimumLength = TrainerNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(TrainerAgeMaxLimit, MinimumLength = TrainerAgeMinLimit)]
        public int Age { get; set; }

        [Required]
        [StringLength(TrainerBioMaxLength, MinimumLength = TrainerBioMinLength)]
        public string Bio { get; set; } = string.Empty;

        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
        public string? ImageUrl { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
