namespace PokeMaster.Domain.Entities;

public class Master
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public short Age { get; set; }
    public string CPF { get; set; } = string.Empty;
    public virtual List<CapturedPokemon> CapturedPokemons { get; set; } = new List<CapturedPokemon>();
    public void AddPokemon(int pokemonId, string pokemonName)
    {
        var captured = new CapturedPokemon() { PokemonId = pokemonId, PokemonName = pokemonName };
        CapturedPokemons.Add(captured);
    }
}
