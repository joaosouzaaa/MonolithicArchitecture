using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface IEmailService
{
    Task SendAppointmentEmailAsync(AppointmentTime appointmentTime);
}
