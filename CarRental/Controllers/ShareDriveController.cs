using CarRental.Models.ShareDrive;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers {
    public class ShareDriveController : Controller {
        public IActionResult PassengerRide() {
            return View(new PassengerRideView());
        }

        [HttpGet]
        public IActionResult DriverOpen() {
            return View(new DriverRide()); 
        }

        /*[HttpPost]
        public Task<IActionResult> DriverOpen(DriverRide driver) {

        }*/
    }
}
