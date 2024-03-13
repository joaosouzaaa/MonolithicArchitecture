using FluentValidation;
using FluentValidation.Results;
using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Interfaces.Settings;
using MonolithicArchitecture.API.Services;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class AppointmentTimeServiceTests
{
    private readonly Mock<IAppointmentTimeRepository> _appointmentTimeRepositoryMock;
    private readonly Mock<IAppointmentTimeMapper> _appointmentTimeMapperMock;
    private readonly Mock<IDoctorAttendantServiceFacade> _doctorAttendantServiceFacadeMock;
    private readonly Mock<IPatientClientServiceFacade> _patientClientServiceFacadeMock;
    private readonly Mock<IScheduleService> _scheduleServiceMock;
    private readonly Mock<IEmailService> _emailServiceMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly Mock<IValidator<AppointmentTime>> _validatorMock;
    private readonly AppointmentTimeService _appointmentTimeService;

    public AppointmentTimeServiceTests()
    {
        _appointmentTimeRepositoryMock = new Mock<IAppointmentTimeRepository>();
        _appointmentTimeMapperMock = new Mock<IAppointmentTimeMapper>();
        _doctorAttendantServiceFacadeMock = new Mock<IDoctorAttendantServiceFacade>();
        _patientClientServiceFacadeMock = new Mock<IPatientClientServiceFacade>();
        _scheduleServiceMock = new Mock<IScheduleService>();
        _emailServiceMock = new Mock<IEmailService>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _validatorMock = new Mock<IValidator<AppointmentTime>>();
        _appointmentTimeService = new AppointmentTimeService(_appointmentTimeRepositoryMock.Object, _appointmentTimeMapperMock.Object, 
            _doctorAttendantServiceFacadeMock.Object, _patientClientServiceFacadeMock.Object, _scheduleServiceMock.Object, _emailServiceMock.Object, 
            _notificationHandlerMock.Object, _validatorMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var appointTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        _doctorAttendantServiceFacadeMock.Setup(d => d.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _patientClientServiceFacadeMock.Setup(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _appointmentTimeRepositoryMock.Setup(a => a.ExistsByTimeAndDoctorAsync(It.IsAny<int>(), It.IsAny<DateTime>()))
            .ReturnsAsync(false);

        var appointmentTime = AppointmentTimeBuilder.NewObject().DomainBuild();
        _appointmentTimeMapperMock.Setup(a => a.SaveToDomain(It.IsAny<AppointmentTimeSave>()))
            .Returns(appointmentTime);

        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<AppointmentTime>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        _appointmentTimeRepositoryMock.Setup(a => a.AddAsync(It.IsAny<AppointmentTime>()))
            .ReturnsAsync(true);

        _scheduleServiceMock.Setup(s => s.AddAsync(It.IsAny<AppointmentTime>()));
        _emailServiceMock.Setup(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()));

        // A
        var addResult = await _appointmentTimeService.AddAsync(appointTimeSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        _appointmentTimeRepositoryMock.Verify(a => a.AddAsync(It.IsAny<AppointmentTime>()), Times.Once());
        _scheduleServiceMock.Verify(s => s.AddAsync(It.IsAny<AppointmentTime>()), Times.Once());
        _emailServiceMock.Verify(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()), Times.Once());

        Assert.True(addResult);
    }

    [Fact]
    public async Task AddAsync_DoctorDoesNotExist_ReturnsFalse()
    {
        // A
        var appointTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        _doctorAttendantServiceFacadeMock.Setup(d => d.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        _scheduleServiceMock.Setup(s => s.AddAsync(It.IsAny<AppointmentTime>()));
        _emailServiceMock.Setup(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()));

        // A
        var addResult = await _appointmentTimeService.AddAsync(appointTimeSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _patientClientServiceFacadeMock.Verify(p => p.ExistsAsync(It.IsAny<int>()), Times.Never());
        _appointmentTimeRepositoryMock.Verify(a => a.ExistsByTimeAndDoctorAsync(It.IsAny<int>(), It.IsAny<DateTime>()), Times.Never());
        _appointmentTimeMapperMock.Verify(a => a.SaveToDomain(It.IsAny<AppointmentTimeSave>()), Times.Never());
        _validatorMock.Verify(v => v.ValidateAsync(It.IsAny<AppointmentTime>(), It.IsAny<CancellationToken>()), Times.Never());
        _appointmentTimeRepositoryMock.Verify(a => a.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _scheduleServiceMock.Verify(s => s.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _emailServiceMock.Verify(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task AddAsync_PatientDoesNotExist_ReturnsFalse()
    {
        // A
        var appointTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        _doctorAttendantServiceFacadeMock.Setup(d => d.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _patientClientServiceFacadeMock.Setup(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(false);

        // A
        var addResult = await _appointmentTimeService.AddAsync(appointTimeSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _appointmentTimeRepositoryMock.Verify(a => a.ExistsByTimeAndDoctorAsync(It.IsAny<int>(), It.IsAny<DateTime>()), Times.Never());
        _appointmentTimeMapperMock.Verify(a => a.SaveToDomain(It.IsAny<AppointmentTimeSave>()), Times.Never());
        _validatorMock.Verify(v => v.ValidateAsync(It.IsAny<AppointmentTime>(), It.IsAny<CancellationToken>()), Times.Never());
        _appointmentTimeRepositoryMock.Verify(a => a.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _scheduleServiceMock.Verify(s => s.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _emailServiceMock.Verify(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task AddAsync_TimeAlreadyExists_ReturnsFalse()
    {
        // A
        var appointTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        _doctorAttendantServiceFacadeMock.Setup(d => d.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _patientClientServiceFacadeMock.Setup(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _appointmentTimeRepositoryMock.Setup(a => a.ExistsByTimeAndDoctorAsync(It.IsAny<int>(), It.IsAny<DateTime>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _appointmentTimeService.AddAsync(appointTimeSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _appointmentTimeMapperMock.Verify(a => a.SaveToDomain(It.IsAny<AppointmentTimeSave>()), Times.Never());
        _validatorMock.Verify(v => v.ValidateAsync(It.IsAny<AppointmentTime>(), It.IsAny<CancellationToken>()), Times.Never());
        _appointmentTimeRepositoryMock.Verify(a => a.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _scheduleServiceMock.Verify(s => s.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _emailServiceMock.Verify(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task AddAsync_EntityInvalid_ReturnsFalse()
    {
        // A
        var appointTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        _doctorAttendantServiceFacadeMock.Setup(d => d.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _patientClientServiceFacadeMock.Setup(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        _appointmentTimeRepositoryMock.Setup(a => a.ExistsByTimeAndDoctorAsync(It.IsAny<int>(), It.IsAny<DateTime>()))
            .ReturnsAsync(false);

        var appointmentTime = AppointmentTimeBuilder.NewObject().DomainBuild();
        _appointmentTimeMapperMock.Setup(a => a.SaveToDomain(It.IsAny<AppointmentTimeSave>()))
            .Returns(appointmentTime);

        var validationFailureList = new List<ValidationFailure>()
        {
            new("ste", "atest"),
            new("ste", "atest"),
            new("ste", "atest")
        };
        var validationResult = new ValidationResult()
        {
            Errors = validationFailureList
        };
        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<AppointmentTime>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // A
        var addResult = await _appointmentTimeService.AddAsync(appointTimeSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count));
        _appointmentTimeRepositoryMock.Verify(a => a.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _scheduleServiceMock.Verify(s => s.AddAsync(It.IsAny<AppointmentTime>()), Times.Never());
        _emailServiceMock.Verify(e => e.SendAppointmentEmailAsync(It.IsAny<AppointmentTime>()), Times.Never());

        Assert.False(addResult);
    }
}
