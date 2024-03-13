using MonolithicArchitecture.API.DataTransferObjects.Schedule;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IScheduleMapper
{
    Schedule AppointmentTimeToDomain(AppointmentTime appointmentTime);
    List<ScheduleResponse> DomainListToResponseList(List<Schedule> scheduleList);
}
