using CarRental.Models;

namespace CarRental.Repository {
    public interface IDriverRepository : IRepository<Driver> {
        public Task<List<Driver>> getAllPending();
    }
}
