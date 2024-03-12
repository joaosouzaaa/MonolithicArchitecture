using MimeKit;

namespace MonolithicArchitecture.API.Interfaces.Settings;
public interface IEmailSender
{
    Task SendEmailAsync(MimeMessage mailMessage);
}
