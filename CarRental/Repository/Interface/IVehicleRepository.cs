using CarRental.Models;

namespace CarRental.Repository.Interface
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        public Task<List<Vehicle>> getAllFromId(string OwnerID);
    }
}
