using CarRental.Data;
using CarRental.Service;
using CarRental.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class DriverController : Controller {

		private readonly DriverService service;
		public DriverController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
			service = new DriverService(context, webHostEnvironment);
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> RegisterDriver() {
            // Get the current logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var result = await service.RegisterDriver(userId);

			if(result.Success) {
                TempData["isPending"] = false;
                return View(new DriverRegistrationView());
            } else {
                // If the driver exists and the status is Pending, inform the user
                TempData["isPending"] = true;
                return View(); // Redirect to a different page, like home or dashboard
            }
		}

		[HttpPost]
		public async Task<IActionResult> RegisterDriver(DriverRegistrationView driverReg) {
			if(ModelState.IsValid) {
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				ServiceResult result = await service.AddDriverAsync(userId, driverReg);
				if (result.Success) {
					TempData["Message"] = "Your application has been submitted and is under review.";
					return RedirectToAction("Index", "Home");
				}
			}
			return View(driverReg);
		}
	}
}
