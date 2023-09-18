using PokeMaster.Infra.Data;
using PokeMaster.Infra.Repositories.Interfaces;

namespace PokeMaster.Infra.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
{
    private readonly PokeMasterDbContext _context;

    public RepositoryBase(PokeMasterDbContext context)
    {
        _context = context;
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Dispose() => _context.Dispose();

    public virtual IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}