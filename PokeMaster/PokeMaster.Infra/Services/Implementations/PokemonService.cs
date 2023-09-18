using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using PokeMaster.Domain.DTOs;
using PokeMaster.Infra.Services.Interfaces;
using Refit;

namespace PokeMaster.Infra.Services.Implementations;

public class PokemonService : IPokemonService
{
    private readonly IPokeAPI _api;

    public PokemonService()
    {
        _api = RestService.For<IPokeAPI>("https://pokeapi.co/api/v2");
    }

    public async Task<PokemonDTO> GetPokemonBasicBy(int id, CancellationToken cancellationToken)
    {
        var response = await _api.GetPokemonBy(id);
        if (response.IsSuccessStatusCode is false)
            throw new Exception("An error occurred while accessing the Pokemon API");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var pokemon = JsonConvert.DeserializeObject<PokemonDTO>(content);
        return pokemon;
    }

    public async Task<PokemonDTO> GetPokemonBy(int id, CancellationToken cancellationToken)
    {
        var response = await _api.GetPokemonBy(id);
        if (response.IsSuccessStatusCode is false)
            throw new Exception("An error occurred while accessing the Pokemon API");

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var pokemon = JsonConvert.DeserializeObject<PokemonDTO>(content);

        var speciesResponse = await _api.GetSpeciesBy(id);
        var speciesContent = await speciesResponse.Content.ReadAsStringAsync(cancellationToken);
        var species = JsonConvert.DeserializeObject<PokemonSpeciesDTO>(speciesContent);

        var evolutionId = species?.EvolutionChain?.GetEvolutionIdFromUrl() ?? 0;

        var evolutionResponse = await _api.GetEvolutionBy(evolutionId);
        var evolutionContent = await evolutionResponse.Content.ReadAsStringAsync(cancellationToken);
        var evolution = JsonConvert.DeserializeObject<EvolutionChainDTO>(evolutionContent);
        pokemon.LoadEvolutions(evolution);
        return pokemon;
    }
}
