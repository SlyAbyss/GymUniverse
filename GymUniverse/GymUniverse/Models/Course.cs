namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Course class that represents a Course that is being tought by a Trainer.
    /// </summary>
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public DateTime Schedule { get; set; }

        public  TimeOnly CourseLength { get; set; }

        public Trainer? Trainer { get; set; }
    }
}
