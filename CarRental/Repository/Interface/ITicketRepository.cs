using CarRental.Models;
using CarRental.Models.ShareDrive;

namespace CarRental.Repository.Interface
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket> GetTicketByID(string id);
    }
}
