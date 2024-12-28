using CarRental.Models;
using CarRental.Models.ShareDrive;

namespace CarRental.Repository {
    public interface IDriverRideRepository : IRepository<DriverRide> {
        public Task<List<DriverRide>> GetValidDriverRides(PassengerRideView passenger);
    }
}
