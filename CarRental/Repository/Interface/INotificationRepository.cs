using CarRental.Models;


namespace CarRental.Repository.Interface
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetUnreadNotifications(string userId);
        Task<List<Notification>> GetAllNotifications(string userId);
        Task<int> GetUnreadNotificationCount(string userId);
        Task MarkAllNotificationsAsRead(string userId);
        Task MarkNotificationAsRead(int notificationId);
    }
}
