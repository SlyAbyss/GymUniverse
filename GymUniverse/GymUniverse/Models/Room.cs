namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Room class that represents a Room in a Location.
    /// </summary>
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public IEnumerable<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}
