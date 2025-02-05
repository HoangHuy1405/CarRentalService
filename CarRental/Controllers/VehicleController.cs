﻿
// VehicleController.cs
using CarRental.Data;
using CarRental.Models;
using CarRental.Service;
using CarRental.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CarRental.Services;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Controllers
{
    public class VehicleController : Controller {
        private VehicleService vehicleService;
        private RentalService rentalService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehicleController(
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment,
            NotificationService notificationService,
            UserManager<ApplicationUser> userManager)
        {
            vehicleService = new VehicleService(context, webHostEnvironment);
            rentalService = new RentalService(context, webHostEnvironment, notificationService, userManager);
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.getAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.Brand.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(vehicles);
        }
        public async Task<IActionResult> AllVehiclePartial(bool isForDetails, int currentId, string searchString)
        {
            IEnumerable<Vehicle> vehicles = await vehicleService.getAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.Brand.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            ViewData["IsForDetails"] = isForDetails;
            ViewData["CurrentId"] = currentId;

            return PartialView("_DisplayVehicles", vehicles);
        }

        [Authorize]
		[HttpGet]
		public async Task<IActionResult> CreateEdit(int id) {
			if (id == 0) {
				// Create
				ViewBag.Operation = "Upload";
				return View(new Vehicle());
			} else {
				// Edit
				ViewBag.Operation = "Edit";
                var queryOption = new QueryOption<Vehicle> {
                    Includes = "Gallery"
                };
                Vehicle vehicle = await vehicleService.GetByIdAsync(id, queryOption);
				return View(vehicle);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateEdit(Vehicle vehicle) {
			vehicle.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (vehicle.RentalVehicleID == 0) {
				if (ModelState.IsValid) {
					//add
					vehicleService.AddVehicleAsync(vehicle);
					return RedirectToAction("Index", "ApplicationUser");
				}
			} else {
				//edit
				// Skip the validation for IFormFile properties (ThumbnailImage, ImageGallery)
				if (vehicle.ThumbnailImage == null) {
					ModelState.Remove("ThumbnailImage"); // Remove validation for ThumbnailImage
				}
				if (vehicle.ImageGallery == null || vehicle.ImageGallery.Count == 0) {
					ModelState.Remove("ImageGallery"); // Remove validation for ImageGallery
				}
				if (ModelState.IsValid) {
					var result = await vehicleService.EditVehicleAsync(vehicle);
					if (!result.Success) {
						ModelState.AddModelError("", result.Errors.FirstOrDefault());
						return View(); // Return an error view
					}

					return RedirectToAction("Index", "ApplicationUser");
				}
				/*if (!ModelState.IsValid) {
					foreach (var key in ModelState.Keys) {
						var errors = ModelState[key].Errors;
						foreach (var error in errors) {
							Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
						}
					}
				}*/
			}
			return View(vehicle);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id) {
			var result = await vehicleService.DeleteVehicleAsync(id);
			if (!result.Success) {
				foreach (var error in result.Errors) {
					ModelState.AddModelError("", error); // Add error messages to ModelState
				}
				return RedirectToAction("Index", "ApplicationUser");
			}
			return RedirectToAction("Index", "ApplicationUser");
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id) {
			var queryOption = new QueryOption<Vehicle> {
				Includes = "Gallery, Owner"
			};
			Vehicle vehicle = await vehicleService.GetByIdAsync(id, queryOption);
			return View(vehicle);
		}

		[HttpGet]
		public async Task<IActionResult> Compare(int currentId, int id) {
			var queryOption = new QueryOption<Vehicle> {
				Includes = "Gallery"
			};

			Vehicle currentVehicle = await vehicleService.GetByIdAsync(currentId, queryOption);
			Vehicle compareVehicle = await vehicleService.GetByIdAsync(id, queryOption);

			List<Vehicle> vehicles = new List<Vehicle>();
			vehicles.Add(currentVehicle);
			vehicles.Add(compareVehicle);

			return View(vehicles);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Rent(int id) {
			var queryOption = new QueryOption<Vehicle> {
				Includes = "Gallery, Owner"
			};
			Rental rent = new Rental();
			rent.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			rent.RentalVehicleID = id;
			return View(rent);
		}

		[HttpGet]
		[Route("api/rentalvehicles/{rentalVehicleId}")]
		public async Task<IActionResult> GetRentalVehicleFee(int rentalVehicleId) {
			// Example: Fetch data from repositories or services
			var queryOption = new QueryOption<Vehicle> {
				Includes = "Gallery, Owner"
			};
			Vehicle vehicleData = await vehicleService.GetByIdAsync(rentalVehicleId, queryOption);

			if (vehicleData == null) {
				return NotFound("Rental Vehicle data not found.");
			}

			return Json(new {
				FeePerDay = vehicleData.RentalFeePerDay,
				OwnerName = vehicleData.Owner.UserName,
				OwnerEmail = vehicleData.Owner.Email,
				OwnerPhone = vehicleData.Owner.PhoneNumber,
			});
		}

		[HttpPost]
		public async Task<IActionResult> Rent(Rental rental) {
			rental.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (ModelState.IsValid) {
				var result = await rentalService.rent(rental);

				if (!result.Success) {
					foreach (var error in result.Errors) {
						ModelState.AddModelError("", error);
					}
					return View(rental);
				}
                TempData["SuccessMessage"] = "Car rental was successful!";
                return RedirectToAction("Index");
			}
			return View(rental);
		}

		/*[HttpGet]
		public async Task<IActionResult> Search(string keyword)
		{
			IEnumerable<Vehicle> vehicles = await vehicleService.searchVehicles(keyword);
			if (!vehicles.Any())
			{
				return NotFound();

			}

			ViewData["IsForDetails"] = false;
			return PartialView("_DisplayVehicles", vehicles);
		}*/
	}
}
