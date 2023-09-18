using Microsoft.Extensions.DependencyInjection;
using PokeMaster.Infra.Services.Implementations;
using PokeMaster.Infra.Services.Interfaces;

namespace PokeMaster.Application;

public static class ServicesDependencieInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddScoped<IMasterService, MasterService>();
        return services;
    }
}
