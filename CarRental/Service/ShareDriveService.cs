using CarRental.Data;
using CarRental.Models;
using CarRental.Models.DTO;
using CarRental.Models.ShareDrive;
using CarRental.Repository;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Service
{
    public class ShareDriveService {
        private readonly DriverRideRepository driverRepo;
        private readonly Repository<PassengerRide> passengerRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ShareDriveService(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            driverRepo = new DriverRideRepository(context);
            passengerRepo = new Repository<PassengerRide>(context);
            _userManager = userManager;
            _context = context;
        }

        // Add this method to update the PassengerRide
        public async Task<ServiceResult> UpdatePassengerRideAsync(PassengerRide model)
        {
            try
            {
                _context.PassengerRides.Update(model);
                await _context.SaveChangesAsync();
                return new ServiceResult { Success = true };
            }
            catch (Exception ex)
            {
                // Log the exception if you have a logging mechanism
                return new ServiceResult { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        // Get Driver Ride By Id
        public async Task<DriverRide> GetDriverRideByIdAsync(int driverRideId)
        {
            return await _context.DriverRides.FindAsync(driverRideId);
        }

        public async Task<DriverRide> GetDriverRideByID(int id) {
            return await driverRepo.GetDriverRideByID(id);
        }

        public async Task<ServiceResult> AddDriverRide(DriverRide driver) {
            try {
                await driverRepo.Add(driver);
                return ServiceResult.SuccessResult();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message); 
                return ServiceResult.FailureResult("Add driverRide to db fails");
            }
        }

        // only check for seats left and date/time
        public async Task<IEnumerable<DriverRideDto>> GetAllValidRides(PassengerRideView passenger) {
            return await driverRepo.GetValidDriverRides(passenger);
        }

        public async Task<ServiceResult> ProcessPassengerRide(PassengerRide passengerRide) {
            try {
                passengerRide.Status = Models.Status.Confirmed;
                await passengerRepo.Add(passengerRide);
                DriverRide? driver = await driverRepo.GetDriverRideByID(passengerRide.DriverRideID);
                if (driver != null) {
                    driver.SeatLeft -= passengerRide.Seats;
                    await driverRepo.Update(driver);
                }
                return ServiceResult.SuccessResult();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ServiceResult.FailureResult("Cannot process passenger ride");
            }

            

        }
    }
}
