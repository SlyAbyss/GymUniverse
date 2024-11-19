namespace GymUniverse.Models
{
    /// <summary>
    ///  This is the Equipment class that represents an Equipment that is being used in a Room.
    /// </summary>
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }
    }
}
