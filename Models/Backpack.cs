using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework7Full.Models;

public class Backpack
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    [ForeignKey("CharacterId")]
    public Character Character { get; set; } = null!;
    public string? Description { get; set; }

}
