using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Services;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IPatientClientService, PatientClientService>();
    }
}
