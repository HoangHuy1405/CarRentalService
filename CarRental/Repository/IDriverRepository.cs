using CarRental.Models;

namespace CarRental.Repository {
    public interface IDriverRepository : IRepository<Driver> {
        public Task<List<Driver>> getAllPending();
        public Task<Driver?> GetDriverByID(string id);
    }
}
