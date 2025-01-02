using CarRental.Models;

namespace CarRental.Repository {
    internal interface IRentalRepository : IRepository<Rental> {
        Task<IEnumerable<Rental>> GetAllFromID(string id);
    }
}