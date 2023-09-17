namespace EntityFramework7Full.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Backpack Backpack { get; set; } = null!;
    public List<Weapon> Weapons { get; set; } = null!;
    public List<Faction> Factions { get; set; } = null!;

}
