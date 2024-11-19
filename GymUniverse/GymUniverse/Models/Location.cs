namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Location class that represents an already opened facility.
    /// </summary>
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Schedule { get; set; } = string.Empty;

        public string Owner { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public IEnumerable<Trainer> Trainers { get; set; } = new List<Trainer>();

        public IEnumerable<Room> Rooms { get; set; } = new List<Room>();
    }
}
