using CarRental.Data;
using CarRental.Models.ShareDrive;
using CarRental.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Controllers {
    public class ShareDriveController : Controller {

        DriverRideService driverRideService;

        public ShareDriveController(ApplicationDbContext context) {
            driverRideService = new DriverRideService(context);
        }

        public IActionResult PassengerRide() {
            return View(new PassengerRideView());
        }

        [HttpGet]
        public IActionResult DriverOpen() {
            return View(new DriverRide()); 
        }

        [HttpPost]
        public async Task<IActionResult> SaveDriverRoute([FromBody] DriverRide driver) {
            if (driver == null) {
                Console.WriteLine("Bad request");
                return BadRequest("Invalid data.");
            } else {
                Console.WriteLine(driver.StartLocation);
                Console.WriteLine(driver.EndLocation);
                Console.WriteLine(driver.DepartDate);
                Console.WriteLine(driver.DepartTime);
                Console.WriteLine(driver.Seats);

                driver.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await driverRideService.AddDriverRide(driver);
                // Save to database service

                if(result.Success) {
                    return Ok(new { message = "Route saved successfully!" });
                } else {
                    return StatusCode(500, "An error occurred while saving the data.");
                }
            }
        }
    }
}
