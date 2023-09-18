using PokeMaster.Domain.Entities;

namespace PokeMaster.Infra.Services.Interfaces;

public interface IMasterService
{
    Task Capture(int masterId, int pokemonId, CancellationToken cancellationToken);
    Task Create(Master master);
    Task<Master> GetMasterBy(int masterId);
}
