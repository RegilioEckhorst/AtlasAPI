using Microsoft.EntityFrameworkCore;

namespace AtlasAPI;

public class DBContext : DbContext
{
    readonly string _dbPath = "";
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Exercises> Exercises { get; set; }
    public DbSet<Reservations> Reservations { get; set; }
    public DbSet<Users> Users { get; set; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");

}
