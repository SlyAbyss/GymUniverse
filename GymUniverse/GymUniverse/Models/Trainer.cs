namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Trainer class that represents a Trainer in a Location.
    /// </summary>
    public class Trainer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}
