using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityFramework7Full.Models;

public class Backpack
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    // [ForeignKey("CharacterId")]
    [JsonIgnore]
    public Character Character { get; set; } = null!;
    public string? Description { get; set; }

}
