using CarRental.Models;

namespace CarRental.Services {
    public interface IVehicleRepository : IRepository<Vehicle> {
        public Task<List<Vehicle>> getAllFromId(string OwnerID);
    }
}
