using CarRental.Models;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository {
    public class DriverRepository : Repository<Driver>, IDriverRepository {
        public DriverRepository(ApplicationDbContext context) : base(context) {

        }
        public async Task<List<Driver>> getAllPending() {
            var pendingDrivers = await context.Drivers
            .Where(d => d.Status == DriverStatus.Pending) // Filter by Pending status
            .ToListAsync(); // Get the list asynchronously

            return pendingDrivers;
        }
        public async Task<Driver?> GetDriverByID(string id) {
            return await context.Drivers
                .Where(d => d.UserID == id)
                .FirstOrDefaultAsync(); // Or SingleOrDefaultAsync() if expecting only one result
        }
    }
}
