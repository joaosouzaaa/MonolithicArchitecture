using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Services;
using Moq;
using UnitTests.TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class ScheduleServiceTests
{
    private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;
    private readonly Mock<IScheduleMapper> _scheduleMapperMock;
    private readonly ScheduleService _scheduleService;

    public ScheduleServiceTests()
    {
        _scheduleRepositoryMock = new Mock<IScheduleRepository>();
        _scheduleMapperMock = new Mock<IScheduleMapper>();
        _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object, _scheduleMapperMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario()
    {
        // A
        var appointmentTime = AppointmentTimeBuilder.NewObject().DomainBuild();

        var schedule = ScheduleBuilder.NewObject().DomainBuild();
        _scheduleMapperMock.Setup(s => s.AppointmentTimeToDomain(It.IsAny<AppointmentTime>()))
            .Returns(schedule);

        _scheduleRepositoryMock.Setup(s => s.AddAsync(It.IsAny<Schedule>()))
            .ReturnsAsync(true);

        // A
        await _scheduleService.AddAsync(appointmentTime);

        // A
        _scheduleMapperMock.Verify(s => s.AppointmentTimeToDomain(It.IsAny<AppointmentTime>()), Times.Once());
        _scheduleRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Schedule>()), Times.Once());
    }
}
