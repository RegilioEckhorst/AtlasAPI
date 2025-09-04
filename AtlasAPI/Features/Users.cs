namespace AtlasAPI.Features;

public class Users
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string Role { get; set; } = "User";// e.g., "Admin", "User"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Navigation properties
    public ICollection<Reservations> Reservations { get; set; } = [];
}
