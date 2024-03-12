using MonolithicArchitecture.API.DataTransferObjects.Schedule;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;

namespace MonolithicArchitecture.API.Mappers;
public sealed class ScheduleMapper : IScheduleMapper
{
    public List<ScheduleResponse> DomainListToResponseList(List<Schedule> scheduleList) =>
        scheduleList.Select(DomainToResponse).ToList();

    private ScheduleResponse DomainToResponse(Schedule schedule) =>
        new()
        {
            Id = schedule.Id,
            Time = schedule.Time
        };
}
