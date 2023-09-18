using PokeMaster.Domain.Entities;

namespace PokeMaster.Application.Responses;

public class MasterResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public short Age { get; set; }
    public string CPF { get; set; } = string.Empty;
    public virtual List<CapturedPokemon> CapturedPokemons { get; set; } = new List<CapturedPokemon>();
}
