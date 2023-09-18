using Newtonsoft.Json;

namespace PokeMaster.Domain.DTOs;

public partial class EvolutionChainDTO
{
    [JsonProperty("chain")]
    public Chain? Chain { get; set; }
}

public partial class Chain
{
    [JsonProperty("species")]
    public Species? Species { get; set; }
    [JsonProperty("evolves_to")]
    public Chain[]? EvolvesTo { get; set; }
}
public partial class Species
{
    [JsonProperty("name")]
    public string? Name { get; set; }
}
