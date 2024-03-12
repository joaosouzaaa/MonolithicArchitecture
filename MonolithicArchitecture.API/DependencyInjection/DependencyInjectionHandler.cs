using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Factories;

namespace MonolithicArchitecture.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString());
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });

        services.AddSettingsDependencyInjection();
        services.AddFilterDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddValidatorsDependencyInjection();
    }
}
