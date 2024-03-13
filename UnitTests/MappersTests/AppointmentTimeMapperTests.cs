using MonolithicArchitecture.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests;
public sealed class AppointmentTimeMapperTests
{
    private readonly AppointmentTimeMapper _appointmentTimeMapper;

    public AppointmentTimeMapperTests()
    {
        _appointmentTimeMapper = new AppointmentTimeMapper();
    }

    [Fact]
    public void SaveToDomain_SuccessfulScenario()
    {
        // A
        var appointmentTimeSave = AppointmentTimeBuilder.NewObject().SaveBuild();

        // A
        var appointmentTimeResult = _appointmentTimeMapper.SaveToDomain(appointmentTimeSave);

        // A
        Assert.Equal(appointmentTimeResult.DoctorAttendantId, appointmentTimeSave.DoctorAttendantId);
        Assert.Equal(appointmentTimeResult.PatientClientId, appointmentTimeSave.PatientClientId);
        Assert.Equal(appointmentTimeResult.Time, appointmentTimeSave.Time);
    }
}
