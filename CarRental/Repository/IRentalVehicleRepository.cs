using CarRental.Models;

namespace CarRental.Services {
    public interface IRentalVehicleRepository : IRepository<RentalVehicle> {
        public Task<List<RentalVehicle>> getAllFromId(string OwnerID);
    }
}
