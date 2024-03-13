using MonolithicArchitecture.API.Interfaces.Settings;
using MonolithicArchitecture.API.Settings.EmailSettings;
using MonolithicArchitecture.API.Settings.NotificationSettings;

namespace MonolithicArchitecture.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<IEmailSender, EmailSender>();
    }
}
