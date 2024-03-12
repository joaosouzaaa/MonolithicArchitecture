using MonolithicArchitecture.API.Settings.NotificationSettings;

namespace MonolithicArchitecture.API.Interfaces.Settings;
public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
    void AddNotification(string v, object value);
}
