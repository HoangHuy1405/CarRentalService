using CarRental.Models;
using CarRental.Models.ShareDrive;

namespace CarRental.Repository {
    public interface ITicketRepository : IRepository<Ticket> {
        Task<Ticket> GetTicketByID(string id);
    }
}
