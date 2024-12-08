using CarRental.Data;
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace CarRental.Controllers {
    public class RentalVehicleController : Controller {
        private Repository<RentalVehicle> rentalVehicleRepo;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public RentalVehicleController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
			rentalVehicleRepo = new Repository<RentalVehicle>(context);
			_webHostEnvironment = webHostEnvironment;
		}

        public async Task<IActionResult> Index() {
            return View(await rentalVehicleRepo.GetAll());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateEdit(int id)  {
            if(id == 0) {
                // Create
                ViewBag.Operation = "Upload";
                return View(new RentalVehicle());
            } else {
				// Edit
				ViewBag.Operation = "Edit";
				var queryOption = new QueryOption<RentalVehicle> {
                    Includes = "Gallery"
                }; 
				RentalVehicle vehicle = await rentalVehicleRepo.GetById(id, queryOption);
				
				return View(vehicle);
			}
        }

		[HttpPost]
		public async Task<IActionResult> CreateEdit(RentalVehicle vehicle) {
			vehicle.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			// Conditional validation for ThumbnailImage and ImageGallery
			
			if (vehicle.RentalVehicleID == 0) {
				if (ModelState.IsValid) {
					//add
					vehicle.Gallery = new List<CarImage>();
					await rentalVehicleRepo.Add(vehicle);
					// thumbnail image
					if (vehicle.ThumbnailImage != null) {
						string folder = "images/Thumbnail/";
						vehicle.ThumbnailUrl = await UploadImage(folder, vehicle.ThumbnailImage);
					}
					// gallery images
					if (vehicle.ImageGallery != null) {
						string folder = "images/Gallery/";
						vehicle.Gallery = new List<CarImage>();
						foreach (var image in vehicle.ImageGallery) {
							var carImage = new CarImage {
								CarImageID = Guid.NewGuid().ToString(), // Generate a unique ID for the primary key
								RentalVehicleID = vehicle.RentalVehicleID,
								ImageUrl = await UploadImage(folder, image) // Upload image and get URL
							};
							vehicle.Gallery.Add(carImage);
						}
						await rentalVehicleRepo.Update(vehicle);
					}
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
					var queryOption = new QueryOption<RentalVehicle> {
						Includes = "Gallery"
					};
					RentalVehicle existingVehicle = await rentalVehicleRepo.GetById(vehicle.RentalVehicleID, queryOption);
					if (existingVehicle == null) {
						ModelState.AddModelError("", "Vehicle not found.");
						return View(existingVehicle);
					}
					existingVehicle.LicensePlate = vehicle.LicensePlate;
					existingVehicle.Brand = vehicle.Brand;
					existingVehicle.Model = vehicle.Model;
					existingVehicle.ManuYear = vehicle.ManuYear;
					existingVehicle.Description = vehicle.Description;
					existingVehicle.RentalFeePerDay = vehicle.RentalFeePerDay;
					existingVehicle.RentalFeePerKilo = vehicle.RentalFeePerKilo;

					// thumbnail image
					if (vehicle.ThumbnailImage != null) {
						string folder = "images/Thumbnail/";
						existingVehicle.ThumbnailUrl = await UploadImage(folder, vehicle.ThumbnailImage);
					} else {
						existingVehicle.ThumbnailUrl = vehicle.ThumbnailUrl;
					}
					// gallery images
					if (vehicle.ImageGallery != null) {
						string folder = "images/Gallery/";
						existingVehicle.Gallery = new List<CarImage>();
						foreach (var image in vehicle.ImageGallery) {
							var carImage = new CarImage {
								CarImageID = Guid.NewGuid().ToString(), // Generate a unique ID for the primary key
								RentalVehicleID = vehicle.RentalVehicleID,
								ImageUrl = await UploadImage(folder, image) // Upload image and get URL
							};
							existingVehicle.Gallery.Add(carImage);
						}
					} else {
						existingVehicle.Gallery = vehicle.Gallery;
					}
					await rentalVehicleRepo.Update(existingVehicle);
					return RedirectToAction("Index", "ApplicationUser");
				}
			}
			if (!ModelState.IsValid) {
				foreach (var key in ModelState.Keys) {
					var errors = ModelState[key]?.Errors;
					if (errors != null && errors.Count > 0) {
						foreach (var error in errors) {
							Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
						}
					}
				}
			}
			return View(vehicle);
		}



		private async Task<string> UploadImage(string folderPath, IFormFile file) {
			// Guid.NewGuid().ToString() to generate 32-bit random to unique identify the file name 
			// incase of duplicates of same names amongus the users
			folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
			string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
			await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
			return "/" + folderPath;
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id) {
            try {
                await rentalVehicleRepo.Delete(id);
                return RedirectToAction("Index", "ApplicationUser");
            } catch {
                ModelState.AddModelError("", "Vehicle not found.");
                return RedirectToAction("Index");
            }
        }
	}
}
