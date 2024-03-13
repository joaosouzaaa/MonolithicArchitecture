using FluentValidation;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;

namespace MonolithicArchitecture.API.Validators;
public sealed class AppointmentTimeValidator : AbstractValidator<AppointmentTime>
{
    public AppointmentTimeValidator()
    {
        RuleFor(a => a.DoctorAttendantId).GreaterThan(0)
            .WithMessage(EMessage.GreaterThan.Description().FormatTo("Doctor Attendant Id", "0"));

        RuleFor(a => a.PatientClientId).GreaterThan(0)
            .WithMessage(EMessage.GreaterThan.Description().FormatTo("Patient Client Id", "0"));

        RuleFor(a => a.Time).GreaterThan(DateTime.Now)
            .WithMessage(EMessage.GreaterThan.Description().FormatTo("Time", "today"));
    }
}
