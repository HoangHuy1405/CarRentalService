using CarRental.Models;

namespace CarRental.Repository.Interface
{
    public interface IDriverRepository : IRepository<Driver>
    {
        public Task<List<Driver>> getAllPending();
    }
}
