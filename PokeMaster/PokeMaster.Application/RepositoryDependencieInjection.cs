using Microsoft.Extensions.DependencyInjection;
using PokeMaster.Infra.Repositories;
using PokeMaster.Infra.Repositories.Interfaces;

namespace PokeMaster.Application;

public static class RepositoryDependencieInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMasterRepository, MasterRepository>();

        return services;
    }
}
