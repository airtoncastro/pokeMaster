using PokeMaster.Domain.DTOs;

namespace PokeMaster.Infra.Services.Interfaces;

public interface IPokemonService
{
    Task<PokemonDTO> GetPokemonBy(int id, CancellationToken cancellationToken);
    Task<PokemonDTO> GetPokemonBasicBy(int id, CancellationToken cancellationToken);
}
