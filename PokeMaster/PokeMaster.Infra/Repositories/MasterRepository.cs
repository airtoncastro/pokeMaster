using PokeMaster.Domain.Entities;
using PokeMaster.Infra.Data;
using PokeMaster.Infra.Repositories.Interfaces;

namespace PokeMaster.Infra.Repositories;

public class MasterRepository : RepositoryBase<Master>, IMasterRepository
{
    public MasterRepository(PokeMasterDbContext context) : base(context)
    {
    }
}
