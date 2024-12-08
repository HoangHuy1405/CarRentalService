﻿using CarRental.Data;
using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Controllers {
    public class ApplicationUserController : Controller {
        private RentalVehicleRepository rentalVehicles;

        public ApplicationUserController(ApplicationDbContext context) {
            rentalVehicles = new RentalVehicleRepository(context);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index() {
            // Get the current user's ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Fetch the user with their cars using the repository
            List<RentalVehicle> vehicles = await rentalVehicles.getAllFromId(userId);

            if (vehicles == null) {
                return NotFound(); // Return 404 if the user is not found
            }

            // Return a view with the rental vehicles (cars) owned by the user
            return View(vehicles); // Pass the list of cars to the view
        }
    }
}