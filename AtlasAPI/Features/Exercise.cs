using AtlasAPI.Features.Categories;

namespace AtlasAPI.Features;

public class Exercise
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string Icon { get; set; } = "default-icon.png"; // Default icon
    public string Color { get; set; } = "#FFFFFF";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Navigation properties
    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Reservations> Reservations { get; set; } = [];
}
