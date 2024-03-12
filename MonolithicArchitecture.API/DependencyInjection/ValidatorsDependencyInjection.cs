using FluentValidation;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Validators;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class ValidatorsDependencyInjection
{
    internal static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AppointmentTime>, AppointmentTimeValidator>();
        services.AddScoped<IValidator<Certification>, CertificationValidator>();
        services.AddScoped<IValidator<ContactInfo>, ContactInfoValidator>();
        services.AddScoped<IValidator<DoctorAttendant>, DoctorAttendantValidator>();
        services.AddScoped<IValidator<PatientClient>, PatientClientValidator>();
        services.AddScoped<IValidator<Speciality>, SpecialityValidator>();
    }
}
