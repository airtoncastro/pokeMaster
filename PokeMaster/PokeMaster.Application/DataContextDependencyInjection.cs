using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokeMaster.Infra.Data;

namespace PokeMaster.Application;
public static class DataContextDependencyInjection
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PokeMasterDbContext>(options => options.UseSqlite(connectionString));
        return services;
    }

    public static void Migration(PokeMasterDbContext context)
    {
        context.Database.Migrate();
    }
}

