using CarRental.Data;
using CarRental.Models.ShareDrive;
using CarRental.Repository;

namespace CarRental.Service {
    public class DriverRideService {
        private readonly Repository<DriverRide> driverRepo;

        public DriverRideService(ApplicationDbContext context) {
            driverRepo = new Repository<DriverRide>(context);
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
    }
}
