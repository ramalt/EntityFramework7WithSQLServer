using System.Text.Json.Serialization;

namespace EntityFramework7Full.Models;

public class Faction
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [JsonIgnore]
    public List<Character> Characters { get; set; } = null!;

}
