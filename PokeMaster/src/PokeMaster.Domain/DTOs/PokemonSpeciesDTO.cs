using Newtonsoft.Json;

namespace PokeMaster.Domain.DTOs;

public class PokemonSpeciesDTO
{
    [JsonProperty("evolution_chain")]
    public SpecieChain? EvolutionChain { get; set; }
}

public partial class SpecieChain
{
    [JsonProperty("url")]
    public Uri? Url { get; set; }
    public int GetEvolutionIdFromUrl()
    {
        if (Url == null || Url.Segments.Length < 5)
            return 0;
        var evolutionId = Url.Segments[4];
        return Convert.ToInt32(evolutionId[..^1]);
    }
}
