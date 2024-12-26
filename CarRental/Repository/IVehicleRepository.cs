using CarRental.Models;

namespace CarRental.Repository {
    public interface IVehicleRepository : IRepository<Vehicle> {
        public Task<List<Vehicle>> getAllFromId(string OwnerID);
    }
}
