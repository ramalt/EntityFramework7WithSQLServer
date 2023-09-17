using EntityFramework7Full.Data;
using EntityFramework7Full.Dtos;
using EntityFramework7Full.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Full.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly AppDbContext _context;

    public CharacterController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> CreateCharacter(int id)
    {
        var character = await _context.Characters.Include(c => c.Backpack)
                                                 .Include(c => c.Weapons)
                                                 .Include(c => c.Factions)
                                                 .FirstOrDefaultAsync(c => c.Id == id);
        if (character != null)
        {
            return Ok(character);
        }

        return NotFound($"character not found with id {id}");
    }

    [HttpPost]
    public async Task<ActionResult<Character>> CreateCharacter(CreateCharacterDto request)
    {
        Character newCharacter = new Character
        {
            Name = request.Name
        };

        Backpack backpack = new Backpack
        {
            Description = request.Backpack.Description,
            Character = newCharacter
        };

        List<Weapon> weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = newCharacter }).ToList();
        List<Faction> factions = request.Factions.Select(w => new Faction { Name = w.Name, Characters = new List<Character> { newCharacter } }).ToList();

        newCharacter.Backpack = backpack;
        newCharacter.Weapons = weapons;
        newCharacter.Factions = factions;

        _context.Characters.Add(newCharacter);
        try
        {
            await _context.SaveChangesAsync();

            var response = await _context.Characters.Include(c => c.Backpack)
                                                    .Include(c => c.Weapons)
                                                    .ToListAsync();
            return Ok(response);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}
