using CarRental.Data;
using CarRental.Models;
using CarRental.Repository;
using System.Linq;

using static CarRental.Service.ServiceResult;

namespace CarRental.Service
{
    public class RentalService
    {
        private Repository<Rental> rentalRepo;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public RentalService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            rentalRepo = new Repository<Rental>(context);
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Rental>> getAllAsync()
        {
            IEnumerable<Rental> rentals = await rentalRepo.GetAll();
            return rentals;
        }

        public async Task<ServiceResult> rent(Rental rental)
        {   
            if(rental.RentalVehicleID == null)
            {
                return FailureResult("Vehicle id is null");
            }

            //check overlap
            if(await isOverlap((int)rental.RentalVehicleID, rental.StartDate, rental.EndDate))
            {
                return FailureResult("Overlap");
            }

            return await AddRentAsync(rental);

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
