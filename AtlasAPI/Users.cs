namespace AtlasAPI;

public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // e.g., "Admin", "User"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Navigation properties
    public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
}
