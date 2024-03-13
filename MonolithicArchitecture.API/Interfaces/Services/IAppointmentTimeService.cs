using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface IAppointmentTimeService
{
    Task<bool> AddAsync(AppointmentTimeSave appointmentTimeSave);
}
