namespace PokeMaster.Domain.Entities;

public class CapturedPokemon
{
    public int Id { get; set; }
    public int MasterId { get; set; }
    public int PokemonId { get; set; }
    public string PokemonName { get; set; } = string.Empty;
    public DateTime CaptureDate { get; set; } = DateTime.UtcNow;
    public virtual Master? Master { get; set; }
}
