using CarRental.Data;
using CarRental.Models;
using CarRental.Repository;
using System.Linq;
using CarRental.Services;
using Microsoft.AspNetCore.Identity;

using static CarRental.Service.ServiceResult;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Service
{
    public class RentalService
    {
        private Repository<Rental> rentalRepo;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NotificationService _notificationService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RentalService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, NotificationService notificationService, UserManager<ApplicationUser> userManager)
        {
            rentalRepo = new Repository<Rental>(context);
            _webHostEnvironment = webHostEnvironment;
            _notificationService = notificationService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Rental>> getAllAsync()
        {
            IEnumerable<Rental> rentals = await rentalRepo.GetAll();
            return rentals;
        }

        public async Task<ServiceResult> rent(Rental rental)
        {
            if (rental.RentalVehicleID == null)
                return FailureResult("Vehicle id is null");

            // Check overlap
            if (await isOverlap((int)rental.RentalVehicleID, rental.StartDate, rental.EndDate))
                return FailureResult("Overlap");

            var result = await AddRentAsync(rental);
            if (result.Success)
            {
                // Create notifications
                var vehicle = await _context.Vehicles.Include(v => v.Owner).FirstOrDefaultAsync(v => v.RentalVehicleID == rental.RentalVehicleID);
                var renter = await _userManager.FindByIdAsync(rental.UserID);

                if (vehicle != null && renter != null)
                {
                    // Renter Notification
                    await _notificationService.CreateNotification(rental.UserID, $"You have rented the '{vehicle.Brand}' of '{vehicle.Owner.UserName}'.");

                    // Owner Notification
                    await _notificationService.CreateNotification(vehicle.OwnerId, $"{renter.UserName} has rented your '{vehicle.Brand} ({vehicle.ManuYear.Year})'.");
                }
            }

            return result;
        }


        public async Task<IEnumerable<Rental>> findByVehilce(int vehicleId)
        {
            IEnumerable<Rental> rentals = await rentalRepo.GetAll();
            return rentals.Where( r =>
            {
                return r.RentalVehicleID == vehicleId;
            });
        }

        public async Task<bool> isVehicleExist(int vehicleId)
        {
            IEnumerable<Rental> rentals = await rentalRepo.GetAll();
            return rentals.Any(r => r.RentalVehicleID == vehicleId);
        }

        private async Task<bool> isOverlap(int vehicleId, DateTime start, DateTime end)
        {
            IEnumerable<Rental> rentals = await rentalRepo.GetAll();
            return rentals.Any(r => r.RentalVehicleID == vehicleId && ((r.StartDate >= start && r.StartDate <= end) || (r.EndDate >= start && r.EndDate <= end)));
        }

        public async Task<ServiceResult> AddRentAsync(Rental rental)
        {
            rental.Status = Status.Confirmed;
            await rentalRepo.Add(rental);
            return SuccessResult();
        }

    }
}
