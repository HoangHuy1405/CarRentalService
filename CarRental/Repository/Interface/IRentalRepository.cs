using CarRental.Models;

namespace CarRental.Repository.Interface
{
    internal interface IRentalRepository : IRepository<Rental>
    {
        Task<IEnumerable<Rental>> GetAllFromID(string id);
    }
}