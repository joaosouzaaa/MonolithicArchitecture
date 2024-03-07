﻿namespace MonolithicArchitecture.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddSettingsDependencyInjection();
        services.AddFilterDependencyInjection();
    }
}