using PokeMaster.Domain.Entities;
using PokeMaster.Infra.Repositories.Interfaces;
using PokeMaster.Infra.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PokeMaster.Infra.Services.Implementations;

public class MasterService : IMasterService
{
    public readonly IMasterRepository _repository;
    private readonly IPokemonService _pokemonService;

    public MasterService(IMasterRepository repository, IPokemonService pokemonService)
    {
        _repository = repository;
        _pokemonService = pokemonService;
    }

    public async Task Capture(int masterId, int pokemonId, CancellationToken cancellationToken)
    {
        var master = await GetMasterBy(masterId);
        var pokemon = await _pokemonService.GetPokemonBy(pokemonId, cancellationToken) ?? throw new Exception($"Pokemon {pokemonId} not found");

        master.AddPokemon(pokemonId, pokemon.Name);
        await _repository.UpdateAsync(master);
    }

    public async Task Create(Master master)
    {
        await _repository.AddAsync(master);
    }

    public async Task<Master> GetMasterBy(int masterId)
    {
        var master = await _repository.Query()
            .Include(m => m.CapturedPokemons)
            .FirstOrDefaultAsync(m => m.Id == masterId)
            ?? throw new Exception($"MasterId {masterId} not found");
        return master;
    }
}
