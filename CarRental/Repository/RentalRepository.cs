using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository {
    public class RentalRepository : Repository<Rental>, IRentalRepository {
        public RentalRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<IEnumerable<Rental>> GetAllFromID(string userId) {
            return await dbSet
                .Include(r => r.RentalVehicle)
                .Include(r => r.User)
                .Where(r => r.UserID == userId)
                .ToListAsync();
        }
    }
}
