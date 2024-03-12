using MimeKit;
using MimeKit.Text;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Interfaces.Settings;

namespace MonolithicArchitecture.API.Services;
public sealed class EmailService(IPatientClientRepositoryFacade patientClientRepository, IEmailSender emailSender,
                                 IConfiguration configuration) : IEmailService
{
    public async Task SendAppointmentEmailAsync(AppointmentTime appointmentTime)
    {
        var to = await patientClientRepository.GetEmailByIdAsync(appointmentTime.PatientClientId);

        var mailMessage = new MimeMessage()
        {
            Subject = "Your appointment is booked!",
            To = { MailboxAddress.Parse(to) },
            Body = new TextPart(TextFormat.Text)
            {
                Text = $"Your appointment is booked to {appointmentTime.Time:dd/MM/yyyy HH:mm}"
            },
            From = { MailboxAddress.Parse(configuration["EmailCredentials:From"]) }
        };

        await emailSender.SendEmailAsync(mailMessage);
    }
}
