using CarRental.Data;
using CarRental.Models.ShareDrive;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class DriverRideRepository : Repository<DriverRide>, IDriverRideRepository {
        public DriverRideRepository(ApplicationDbContext context) : base(context) {

        }

        public async Task<List<DriverRide>> GetValidDriverRides(PassengerRideView passenger) {
            if (passenger == null) {
                throw new ArgumentNullException(nameof(passenger), "Passenger data cannot be null.");
            }

            var query = context.DriverRides.AsQueryable();

            // Filter by seats (Passenger.Seats <= DriverRide.SeatLeft)
            query = query.Where(driverRide => passenger.Seats <= driverRide.SeatLeft);

            // Filter by DepartTime if provided
            /*if (passenger.DepartTime.HasValue) {
                query = query.Where(driverRide => driverRide.DepartTime == passenger.DepartTime.Value);
            }*/
            // => no need to query exact time.

            // Filter by DepartDate if provided
            if (passenger.DepartDate.HasValue) {
                query = query.Where(driverRide => driverRide.DepartDate == passenger.DepartDate.Value);
            }

            return await query.ToListAsync();
        }
    }
}
