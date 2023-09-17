using EntityFramework7Full.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Full.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Faction> Factions { get; set; }

}
