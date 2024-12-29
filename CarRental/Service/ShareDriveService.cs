using CarRental.Data;
using CarRental.Models.DTO;
using CarRental.Models.ShareDrive;
using CarRental.Repository;

namespace CarRental.Service
{
    public class ShareDriveService {
        private readonly DriverRideRepository driverRepo;
        private readonly Repository<PassengerRide> passengerRepo; 

        public ShareDriveService(ApplicationDbContext context) {
            driverRepo = new DriverRideRepository(context);
            passengerRepo = new Repository<PassengerRide>(context);
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
