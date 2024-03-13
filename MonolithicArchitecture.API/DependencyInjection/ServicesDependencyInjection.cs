using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Services;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeService, AppointmentTimeService>();

        services.AddScoped<IDoctorAttendantService, DoctorAttendantService>();
        services.AddScoped<IDoctorAttendantServiceFacade, DoctorAttendantService>();

        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IPatientClientService, PatientClientService>();
        services.AddScoped<IPatientClientServiceFacade, PatientClientService>();

        services.AddScoped<IScheduleService, ScheduleService>();
        
        services.AddScoped<ISpecialityService, SpecialityService>();
        services.AddScoped<ISpecialityServiceFacade, SpecialityService>();
    }
}
