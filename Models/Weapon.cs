namespace EntityFramework7Full.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;
}
 