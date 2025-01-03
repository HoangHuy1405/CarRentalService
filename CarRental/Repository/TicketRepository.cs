using CarRental.Data;
using CarRental.Models;
using CarRental.Models.ShareDrive;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository {
        public TicketRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<Ticket> GetTicketByID(string id) {
            // Assuming _dbContext is your DbContext instance
            var ticket = await context.Tickets.FirstOrDefaultAsync(t => t.TicketID == id);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsByUserID(string userId) {
            return await dbSet
               .Include(t => t.PassengerRide) // Include the PassengerRide data (one-to-one relationship)
               .Where(t => t.PassengerRide.PassengerID == userId) // Filter by the UserID in PassengerRide
               .ToListAsync();
        }

    }
}
