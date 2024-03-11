using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IAppointmentTimeMapper
{
    AppointmentTime SaveToDomain(AppointmentTimeSave appointmentTimeSave);
}
