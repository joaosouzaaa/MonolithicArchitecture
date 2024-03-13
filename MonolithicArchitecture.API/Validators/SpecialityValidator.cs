using FluentValidation;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;

namespace MonolithicArchitecture.API.Validators;
public sealed class SpecialityValidator : AbstractValidator<Speciality>
{
    public SpecialityValidator()
    {
        RuleFor(s => s.Name).NotEmpty().Length(1, 100)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("Name", "1 to 100"));
    }
}
