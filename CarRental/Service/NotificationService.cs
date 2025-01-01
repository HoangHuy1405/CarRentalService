// Services/NotificationService.cs
using CarRental.Data;
using CarRental.Models;
using CarRental.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class NotificationService
    {
        private NotificationRepository _notificationRepository;


        public NotificationService(ApplicationDbContext context)
        {
            _notificationRepository = new NotificationRepository(context);
        }

        // Create a new notification
        public async Task CreateNotification(string userId, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };
            await _notificationRepository.Add(notification);
            //await _notificationRepository.SaveChangesAsync();
        }

        // Get unread notifications for a user
        public async Task<List<Notification>> GetUnreadNotifications(string userId)
        {
            return await _notificationRepository.GetUnreadNotifications(userId);
        }

        // Mark a notification as read
        public async Task MarkNotificationAsRead(int notificationId)
        {
            await _notificationRepository.MarkNotificationAsRead(notificationId);
        }

        // Mark all notifications for a user as read
        public async Task MarkAllNotificationsAsRead(string userId)
        {
            await _notificationRepository.MarkAllNotificationsAsRead(userId);
        }

        // Get the count of unread notifications
        public async Task<int> GetUnreadNotificationCount(string userId)
        {
            return await _notificationRepository.GetUnreadNotificationCount(userId);
        }

        public async Task<List<Notification>> GetAllNotifications(string userId)
        {
            return await _notificationRepository.GetAllNotifications(userId);
        }
    }
}