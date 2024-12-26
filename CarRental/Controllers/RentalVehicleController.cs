
using CarRental.Data;
using CarRental.Models;
using CarRental.Service;
using CarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRental.Controllers
{
    public class RentalVehicleController : Controller {
        

		private RentalVehicleService service;

		public RentalVehicleController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {

            service = new RentalVehicleService(context, webHostEnvironment);
        }
        public async Task<IActionResult> Index() {
			return View();
        }
        // In RentalVehicleController.cs

        public async Task<IActionResult> AllVehiclePartial(bool isForDetails, int currentId, string searchString)
        {
            IEnumerable<RentalVehicle> vehicles = await service.getAllAsync();

            if (!System.String.IsNullOrEmpty(searchString))
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
				return View(new RentalVehicle());
			} else {
				// Edit
				ViewBag.Operation = "Edit";
                var queryOption = new QueryOption<RentalVehicle> {
                    Includes = "Gallery"
                };
                RentalVehicle vehicle = await service.GetByIdAsync(id, queryOption);
				return View(vehicle);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateEdit(RentalVehicle vehicle) {
			vehicle.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (vehicle.RentalVehicleID == 0) {
				if (ModelState.IsValid) {
					//add
					service.AddVehicleAsync(vehicle);
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
                    var result = await service.EditVehicleAsync(vehicle);
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
            var result = await service.DeleteVehicleAsync(id);
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
			var queryOption = new QueryOption<RentalVehicle> {
				Includes = "Gallery, Owner"
			};
			RentalVehicle vehicle = await service.GetByIdAsync(id, queryOption);
			return View(vehicle);
		}

		[HttpGet]
		public async Task<IActionResult> Compare(int currentId, int id) {
			var queryOption = new QueryOption<RentalVehicle> {
				Includes = "Gallery"
			};

			RentalVehicle currentVehicle = await service.GetByIdAsync(currentId, queryOption);
			RentalVehicle compareVehicle = await service.GetByIdAsync(id, queryOption);

			List<RentalVehicle> vehicles = new List<RentalVehicle>();
			vehicles.Add(currentVehicle);
			vehicles.Add(compareVehicle);

			return View(vehicles);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Rent(int id) {
			var queryOption = new QueryOption<RentalVehicle> {
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
			var queryOption = new QueryOption<RentalVehicle> {
				Includes = "Gallery, Owner"
			};
			RentalVehicle vehicleData = await service.GetByIdAsync(rentalVehicleId, queryOption);

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
				// must add the functionality to validate the overlapping of the rental vehicle id 
				// before can actually 
				var result = await service.AddRentAsync(rental);
                if (!result.Success) {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("", error); // Add error messages to ModelState
                    }
                    return View(rental);
                }
                return RedirectToAction("Index");
			}
			return View(rental);
		}
	}
}
