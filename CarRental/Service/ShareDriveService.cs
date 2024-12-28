using CarRental.Data;
using CarRental.Models.ShareDrive;
using CarRental.Repository;

namespace CarRental.Service {
    public class ShareDriveService {
        private readonly DriverRideRepository driverRepo;

        public ShareDriveService(ApplicationDbContext context) {
            driverRepo = new DriverRideRepository(context);
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
        public async Task<IEnumerable<DriverRide>> GetAllValidRides(PassengerRideView passenger) {
            return await driverRepo.GetValidDriverRides(passenger);
        }
    }
}
