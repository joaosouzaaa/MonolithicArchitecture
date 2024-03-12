using MonolithicArchitecture.API.DataTransferObjects.Schedule;
using MonolithicArchitecture.API.Entities;

namespace UnitTests.TestBuilders;
public sealed class ScheduleBuilder
{
    private readonly int _id = 123;
    private readonly int _doctorAttendantId;
    private readonly DateTime _time = DateTime.Now;

    public static ScheduleBuilder NewObject() =>
        new();

    public Schedule DomainBuild() =>
        new()
        {
            DoctorAttendantId = _doctorAttendantId,
            Time = _time
        };

    public ScheduleResponse ResponseBuild() =>
        new()
        {
            Id = _id,
            Time = _time
        };
}
