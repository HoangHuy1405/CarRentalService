using Azure.Core;
using CarRental.Data;
using CarRental.Models.ShareDrive;
using CarRental.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json;
using CarRental.Repository;
using CarRental.Models.ModelView;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    public class ShareDriveController : Controller {

        private readonly ShareDriveService shareDriveService;

        public ShareDriveController(ApplicationDbContext context) {
            shareDriveService = new ShareDriveService(context);
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

                driver.DriverID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                driver.SeatLeft = driver.Seats;
                var result = await shareDriveService.AddDriverRide(driver);
                // Save to database service

                if(result.Success) {
                    return Ok(new { message = "Route saved successfully!" });
                } else {
                    return StatusCode(500, "An error occurred while saving the data.");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetALLValidDriverRide([FromBody] PassengerRideView passenger) {
            Console.WriteLine(passenger.StartLocation);
            Console.WriteLine(passenger.EndLocation);
            Console.WriteLine(passenger.Seats);
            Console.WriteLine(passenger.DepartTime);
            Console.WriteLine(passenger.DepartDate);
            if (passenger == null) {
                return BadRequest("passenger is invalid!");
            }

            IEnumerable<DriverRide> drivers = await shareDriveService.GetAllValidRides(passenger);
            return Json(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseDriverPost([FromBody] ChooseDriverView request) {
            if (request == null || request.Drivers == null || request.passenger == null) {
                return BadRequest("Invalid request data. ChooseDriver");
            }
            Console.WriteLine("Choose driver valid " + request);
            TempData["ChooseDriverData"] = JsonConvert.SerializeObject(request); // Pass data via TempData or query string
            return RedirectToAction("ChooseDriver", "ShareDrive"); // Redirect to the GET method
         }

        [HttpGet]
        public async Task<IActionResult> ChooseDriver() {
            Console.WriteLine("Redirect to action ChooseDriver()");

            var requestData = TempData["ChooseDriverData"];
            if (requestData == null) {
                Console.WriteLine("No data in TempData for ChooseDriverData");
                return View(new ChooseDriverView()); // Pass an empty model to prevent null references
            }

            ChooseDriverView request = JsonConvert.DeserializeObject<ChooseDriverView>(requestData.ToString());
            TempData.Keep("ChooseDriverData"); // Retain TempData for subsequent requests

            Console.WriteLine($"Returning view: ChooseDriver with model {JsonConvert.SerializeObject(request)}");

            return View("ChooseDriver", request);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(string PassengerStartLocation, string PassengerEndLocation, int PassengerSeats, string PassengerDepartTime, string PassengerDepartDate, int DriverRideID) {
            // Parse the passenger departure time and date if needed
            TimeOnly? departTime = !string.IsNullOrEmpty(PassengerDepartTime) ? TimeOnly.Parse(PassengerDepartTime) : null;
            DateTime? departDate = !string.IsNullOrEmpty(PassengerDepartDate) ? DateTime.Parse(PassengerDepartDate) : null;

            // Retrieve the driver ride details using DriverRideID
            DriverRide driverRide = await shareDriveService.GetDriverRideByID(DriverRideID);

            if (driverRide == null) {
                return NotFound("Invalid driver ride.");
            }
            PassengerRide passengerRide = new PassengerRide {
                PassengerID = User.FindFirstValue(ClaimTypes.NameIdentifier),
                StartLocation = PassengerStartLocation,
                EndLocation = PassengerEndLocation,
                Seats = PassengerSeats,
                DepartTime = departTime,
                DepartDate = departDate,
                DriverRideID = DriverRideID,
                DriverRide = driverRide,
                Status = Models.Status.Pending
            };

            return View("ShareDrivePayment", passengerRide);
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PassengerRide passengerRide) {
            Console.WriteLine(passengerRide.ToString());
            var result = await shareDriveService.ProcessPassengerRide(passengerRide);
            if(result.Success) {
                return RedirectToAction("PassengerRide");
            }
            return RedirectToAction("PassengerRide");
        }

    }
}
