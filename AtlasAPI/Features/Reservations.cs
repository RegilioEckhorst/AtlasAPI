using AtlasAPI.Features.Categories;

namespace AtlasAPI.Features;

public class Reservations
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } // e.g., "Pending", "Confirmed", "Cancelled"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Foreign keys
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public int CategoryId { get; set; }
    // Navigation properties
    public Users User { get; set; }
    public Exercise Exercise { get; set; }
    public Category Category { get; set; }
}
