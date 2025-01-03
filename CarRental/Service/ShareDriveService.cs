using CarRental.Data;
using CarRental.Models;
using CarRental.Models.DTO;
using CarRental.Models.ShareDrive;
using CarRental.Repository;

namespace CarRental.Service
{
    public class ShareDriveService {
        private readonly DriverRideRepository driverRepo;
        private readonly Repository<PassengerRide> passengerRepo;
        private readonly ApplicationUserRepository userRepo;

        public ShareDriveService(ApplicationDbContext context) {
            driverRepo = new DriverRideRepository(context);
            passengerRepo = new Repository<PassengerRide>(context);
            userRepo = new ApplicationUserRepository(context);
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
                float balance = userRepo.GetUserById(passengerRide.PassengerID).Result.Balance;
                if (balance < passengerRide.DepositFee) {
                    return ServiceResult.FailureResult("Insufficient Fund");
                }
                await userRepo.SubtractMoneyFromBalance(passengerRide.PassengerID, passengerRide.DepositFee);

                passengerRide.Status = Models.Status.Confirmed;
                await passengerRepo.Add(passengerRide);
                DriverRide? driver = await driverRepo.GetDriverRideByID(passengerRide.DriverRideID);
                if (driver != null) {
                    await userRepo.AddMoneyToBalance(driver.DriverID, passengerRide.DepositFee);
                    driver.SeatLeft -= passengerRide.Seats;
                    await driverRepo.Update(driver);
                }
                return ServiceResult.SuccessResult();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ServiceResult.FailureResult("Cannot process passenger ride");
            }
        }
        public async Task<ServiceResult> ProcessRefund(int DriverRideID) {
            try {

                DriverRide? driverRide = await driverRepo.GetById(DriverRideID, new QueryOption<DriverRide>()
                {
                    Includes = "PassengerRides"
                }) ?? throw new Exception("Driver ride not found");
                List<PassengerRide> passengerRides = driverRide.PassengerRides.Where(p => p.Status == Status.Confirmed).ToList();

                foreach (PassengerRide passengerRide in passengerRides) {
                    await userRepo.SubtractMoneyFromBalance(driverRide.DriverID, passengerRide.DepositFee);
                    await userRepo.AddMoneyToBalance(passengerRide.PassengerID, passengerRide.DepositFee);
                    passengerRide.Status = Status.Cancelled;
                    await passengerRepo.Update(passengerRide);
                }
                
                await driverRepo.Update(driverRide);

                return ServiceResult.SuccessResult();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ServiceResult.FailureResult("Cannot process refund");
            }
        }

        public async Task<IEnumerable<DriverRideDto>> GetAllDriverRideByID(string driverID) {
            return await driverRepo.GetAllDriverRideByID(driverID);
        }

        public async Task<IEnumerable<PassengerRideDto>> GetPassRidesOfDriverRide(int driverRide) {
            return await driverRepo.GetPassRidesOfDriverRide(driverRide);
        }


    }
}
