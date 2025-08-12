namespace AtlasAPI;

public class Categories
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Icon { get; set; } = "default-icon.png"; // Default icon
    public string Color { get; set; } = "#FFFFFF"; // Default color
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Navigation properties
    public ICollection<Exercises> Exercises { get; set; } = [];
    public ICollection<Reservations> Reservations { get; set; } = [];
}
