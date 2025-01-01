using CarRental.Models;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class NotificationRepository : Repository<Notification>
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetUnreadNotifications(string userId)
        {
            return await context.Notifications.Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetAllNotifications(string userId)
        {
            return await context.Notifications.Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetUnreadNotificationCount(string userId)
        {
            return await context.Notifications.Where(n => n.UserId == userId && !n.IsRead)
                .CountAsync();
        }

        public async Task MarkAllNotificationsAsRead(string userId)
        {
            var notifications = await context.Notifications.Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }
            await context.SaveChangesAsync();
        }

        public async Task MarkNotificationAsRead(int notificationId)
        {
            var notification = await context.Notifications.FindAsync(notificationId);
            notification.IsRead = true;
            await context.SaveChangesAsync();
        }
    }
}
