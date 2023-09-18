namespace PokeMaster.Infra.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity);

    IQueryable<TEntity> Query();

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

}
