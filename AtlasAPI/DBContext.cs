using AtlasAPI.Features;
using AtlasAPI.Features.Categories;
using AtlasAPI.Features.Excercise;
using Microsoft.EntityFrameworkCore;

namespace AtlasAPI;

public class DBContext : DbContext
{
    public readonly string _dbPath = "";

    public DBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = System.IO.Path.Join(path, "blogging.db");

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Reservations> Reservations { get; set; }
    public DbSet<Users> Users { get; set; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");

}
