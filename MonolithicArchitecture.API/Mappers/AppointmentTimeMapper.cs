using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;

namespace MonolithicArchitecture.API.Mappers;
public sealed class AppointmentTimeMapper : IAppointmentTimeMapper
{
    public AppointmentTime SaveToDomain(AppointmentTimeSave appointmentTimeSave) =>
        new()
        {
            DoctorAttendantId = appointmentTimeSave.DoctorAttendantId,
            PatientClientId = appointmentTimeSave.PatientClientId,
            Time = appointmentTimeSave.Time
        };
}
