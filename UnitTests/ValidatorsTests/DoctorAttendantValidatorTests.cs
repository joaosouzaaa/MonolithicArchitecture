﻿using MonolithicArchitecture.API.Validators;
using UnitTests.TestBuilders;

namespace UnitTests.ValidatorsTests;
public sealed class DoctorAttendantValidatorTests
{
    private readonly DoctorAttendantValidator _doctorAttendantValidator;

    public DoctorAttendantValidatorTests()
    {
        _doctorAttendantValidator = new DoctorAttendantValidator();
    }

    [Fact]
    public async Task ValidateAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var doctorAttendantToValidate = DoctorAttendantBuilder.NewObject().DomainBuild();

        // A
        var validationResult = await _doctorAttendantValidator.ValidateAsync(doctorAttendantToValidate);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Fact]
    public async Task ValidateAsync_InvalidCertification_ReturnsFalse()
    {
        // A
        var invalidCertification = CertificationBuilder.NewObject().WithLicenseNumber("a").DomainBuild();
        var doctorAttendantWithInvalidCertification = DoctorAttendantBuilder.NewObject().WithCertification(invalidCertification).DomainBuild();

        // A
        var validationResult = await _doctorAttendantValidator.ValidateAsync(doctorAttendantWithInvalidCertification);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidNameParameters))]
    public async Task ValidateAsync_InvalidName_ReturnsFalse(string name)
    {
        // A
        var doctorAttendantWithInvalidName = DoctorAttendantBuilder.NewObject().WithName(name).DomainBuild();

        // A
        var validationResult = await _doctorAttendantValidator.ValidateAsync(doctorAttendantWithInvalidName);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static TheoryData<string> InvalidNameParameters() =>
        new()
        {
            "",
            new string('a', count: 102)
        };

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-21)]
    public async Task ValidateAsync_InvalidExperienceYears_ReturnsFalse(int experienceYears)
    {
        // A
        var doctorAttendantWithExperienceYears = DoctorAttendantBuilder.NewObject().WithExperienceYears(experienceYears).DomainBuild();

        // A
        var validationResult = await _doctorAttendantValidator.ValidateAsync(doctorAttendantWithExperienceYears);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidBirthDateParameters))]
    public async Task ValidateAsync_InvalidBirthdate_ReturnsFalse(DateOnly birthDate)
    {
        // A
        var doctorAttendantWithInvalidBirthDate = DoctorAttendantBuilder.NewObject().WithBirthDate(birthDate).DomainBuild();

        // A
        var validationResult = await _doctorAttendantValidator.ValidateAsync(doctorAttendantWithInvalidBirthDate);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static TheoryData<DateOnly> InvalidBirthDateParameters() =>
        new()
        {
            new DateOnly(DateTime.Now.AddYears(-200).Year, 01, 01)
        };
}
