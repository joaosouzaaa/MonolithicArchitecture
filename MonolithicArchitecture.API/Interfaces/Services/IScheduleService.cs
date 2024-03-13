using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface IScheduleService
{
    Task AddAsync(AppointmentTime appointmentTime);
}
