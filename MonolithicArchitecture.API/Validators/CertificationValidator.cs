using FluentValidation;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;

namespace MonolithicArchitecture.API.Validators;
public sealed class CertificationValidator : AbstractValidator<Certification>
{
    public CertificationValidator()
    {
        RuleFor(c => c.LicenseNumber).Length(20)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("License Number", "20"));
    }
}
