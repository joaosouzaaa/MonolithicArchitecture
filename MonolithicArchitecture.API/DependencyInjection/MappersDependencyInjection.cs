using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Mappers;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeMapper, AppointmentTimeMapper>();
        services.AddScoped<ICertificationMapper, CertificationMapper>();
        services.AddScoped<IContactInfoMapper, ContactInfoMapper>();
        services.AddScoped<IDoctorAttendantMapper, DoctorAttendantMapper>();
        services.AddScoped<IPatientClientMapper, PatientClientMapper>();
        services.AddScoped<IScheduleMapper, ScheduleMapper>();
        services.AddScoped<ISpecialityMapper, SpecialityMapper>();
    }
}
