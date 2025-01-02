using CarRental.Data;
using CarRental.Models;
using CarRental.Models.ShareDrive;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository {
    public class TicketRepository : Repository<Ticket>, ITicketRepository {
        public TicketRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<Ticket> GetTicketByID(string id) {
            // Assuming _dbContext is your DbContext instance
            var ticket = await context.Tickets.FirstOrDefaultAsync(t => t.TicketID == id);
            return ticket;
        }

    }
}
