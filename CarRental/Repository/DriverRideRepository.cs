using CarRental.Data;
using CarRental.Models.ShareDrive;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class DriverRideRepository : Repository<DriverRide>, IDriverRideRepository {
        public DriverRideRepository(ApplicationDbContext context) : base(context) {

        }

        public async Task<DriverRide?> GetDriverRideByID(int id) {
            return await context.DriverRides
                .Include(dr => dr.Driver!) // Include the Driver
                .ThenInclude(d => d.User!) // Include the User inside the Driver
                .FirstOrDefaultAsync(dr => dr.DriverRideID == id);
        }

        public async Task<List<DriverRide>> GetValidDriverRides(PassengerRideView passenger) {
            if (passenger == null) {
                throw new ArgumentNullException(nameof(passenger), "Passenger data cannot be null.");
            }

            var query = context.DriverRides
            .Include(driverRide => driverRide.Driver!) // Include Driver information
            .ThenInclude(driver => driver.User) // Include ApplicationUser for additional details
            .AsQueryable();

            // Filter by seats (Passenger.Seats <= DriverRide.SeatLeft)
            query = query.Where(driverRide => passenger.Seats <= driverRide.SeatLeft);

            // Filter by DepartDate if provided
            if (passenger.DepartDate.HasValue) {
                query = query.Where(driverRide => driverRide.DepartDate == passenger.DepartDate.Value);
            }

            return await query.ToListAsync();
        }
    }
}
