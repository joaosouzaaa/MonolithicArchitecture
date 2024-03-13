using MonolithicArchitecture.API.Data.Repositories;
using MonolithicArchitecture.API.Interfaces.Repositories;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeRepository, AppointmentTimeRepository>();
        services.AddScoped<IDoctorAttendantRepository, DoctorAttendantRepository>();

        services.AddScoped<IPatientClientRepository, PatientClientRepository>();
        services.AddScoped<IPatientClientRepositoryFacade, PatientClientRepository>();

        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
    }
}
