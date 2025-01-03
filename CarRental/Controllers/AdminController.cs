using CarRental.Data;
using CarRental.Models;
using CarRental.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers {
    public class AdminController : Controller {
        private DriverApprovalService _driverService;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            _driverService = new DriverApprovalService(context, userManager, signInManager);
        }

        [HttpGet]
        public async Task<IActionResult> Approve() {
            IEnumerable<Driver> drivers = await _driverService.getAllPending();
            return View(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(string id) {
            var result = await _driverService.ApproveDriverAsync(id); // Approve driver ogic
            if (result.Success) {
                TempData["Message"] = "Driver approved successfully!";
            } else {
                TempData["Message"] = "Failed to approve the driver.";
            }

            return RedirectToAction("Approve");
        }

        [HttpPost]
        public async Task<IActionResult> Reject(string id) {
            var result = await _driverService.RejectDriverAsync(id); // Reject driver logic
            if (result.Success) {
                TempData["Message"] = "Driver reject successfully!";
            } else {
                TempData["Message"] = "Failed to reject the driver.";
            }
            return RedirectToAction("Approve");
        }
    }
}
