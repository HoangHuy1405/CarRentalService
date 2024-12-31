// Controller/NotificationController.cs
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
[Route("Notification")]
public class NotificationController : Controller
{
    private readonly NotificationService _notificationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public NotificationController(NotificationService notificationService, UserManager<ApplicationUser> userManager)
    {
        _notificationService = notificationService;
        _userManager = userManager;
    }

    [HttpGet("GetNotifications")]
    public async Task<IActionResult> GetNotifications()
    {
        var userId = _userManager.GetUserId(User);
        var notifications = await _notificationService.GetAllNotifications(userId); // Use the new method
        return Json(notifications);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Unauthorized();

        var notifications = await _notificationService.GetAllNotifications(userId);
        return Json(notifications);
    }

    [HttpPost]
    public async Task<IActionResult> MarkAllAsRead()
    {
        var userId = _userManager.GetUserId(User);
        await _notificationService.MarkAllNotificationsAsRead(userId);
        return Ok();
    }

}