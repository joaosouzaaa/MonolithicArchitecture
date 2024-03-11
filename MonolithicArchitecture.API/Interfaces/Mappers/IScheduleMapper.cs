using MonolithicArchitecture.API.DataTransferObjects.Schedule;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IScheduleMapper
{
    List<ScheduleResponse> DomainListToResponseList(List<Schedule> scheduleList);
}
