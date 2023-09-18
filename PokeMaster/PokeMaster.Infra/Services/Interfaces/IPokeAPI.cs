using Refit;

namespace PokeMaster.Infra.Services;

public interface IPokeAPI
{
    [Get("/pokemon/{id}")]
    Task<HttpResponseMessage> GetPokemonBy(int id);

    [Get("/pokemon-species/{id}")]
    Task<HttpResponseMessage> GetSpeciesBy(int id);
    [Get("/evolution-chain/{id}")]
    Task<HttpResponseMessage> GetEvolutionBy(int id);

}
