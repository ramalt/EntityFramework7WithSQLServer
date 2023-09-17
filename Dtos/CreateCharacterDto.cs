using EntityFramework7Full.Models;

namespace EntityFramework7Full.Dtos;

public record CreateCharacterDto(string Name,
                                 CreateBackpackDto Backpack,
                                 List<CreateWeaponDto> Weapons,
                                 List<CreateFactionDto> Factions);
