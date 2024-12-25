﻿using CarRental.Data;
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Hosting;


namespace CarRental.Service
{
    public class RentalVehicleService
    {
        private Repository<RentalVehicle> rentalVehicleRepo;
        private Repository<Rental> rentalRepo;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public RentalVehicleService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            rentalVehicleRepo = new Repository<RentalVehicle>(context);
            rentalRepo = new Repository<Rental>(context);

            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IEnumerable<RentalVehicle>> getAllAsync() {
            IEnumerable<RentalVehicle> vehicles = await rentalVehicleRepo.GetAll();
            return vehicles;
        }

        public async Task<RentalVehicle> GetByIdAsync(int id, QueryOption<RentalVehicle> options) {
            RentalVehicle vehicle = await rentalVehicleRepo.GetById(id, options);
            return vehicle;
        }

        public async void AddVehicleAsync(RentalVehicle vehicle) {
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
        }
        public async Task<ServiceResult> EditVehicleAsync(RentalVehicle vehicle) {
            // Skip the validation for IFormFile properties (ThumbnailImage, ImageGallery)

            var queryOption = new QueryOption<RentalVehicle> {
                Includes = "Gallery"
            };
            RentalVehicle existingVehicle = await rentalVehicleRepo.GetById(vehicle.RentalVehicleID, queryOption);
            if (existingVehicle == null) {
                // return error
                return ServiceResult.FailureResult("vehicle not found");
            }
            existingVehicle.LicensePlate = vehicle.LicensePlate;
            existingVehicle.Brand = vehicle.Brand;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.ManuYear = vehicle.ManuYear;
            existingVehicle.Description = vehicle.Description;
            existingVehicle.RentalFeePerDay = vehicle.RentalFeePerDay;
            existingVehicle.RentalFeePerKilo = vehicle.RentalFeePerKilo;

            existingVehicle.Transmission = vehicle.Transmission;
            existingVehicle.FuelType = vehicle.FuelType;
            existingVehicle.FuelConsumption = vehicle.FuelConsumption;
            existingVehicle.Location = vehicle.Location;
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
            return ServiceResult.SuccessResult();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file) {
            // Guid.NewGuid().ToString() to generate 32-bit random to unique identify the file name 
            // incase of duplicates of same names amongus the users
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

        public async Task<ServiceResult> DeleteVehicleAsync(int id) {
            try {
                await rentalVehicleRepo.Delete(id);
                return ServiceResult.SuccessResult();
            } catch {
                return ServiceResult.FailureResult("Vehicle not found.");
            }
        }




    }
}
