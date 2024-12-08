using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services {
    public class RentalVehicleRepository : Repository<RentalVehicle>, IRentalVehicleRepository {
        public RentalVehicleRepository(ApplicationDbContext context) : base(context) {

        }

        public async Task<List<RentalVehicle>> getAllFromId(string OwnerID) {
			var allVehicles = await context.RentalVehicles.ToListAsync();
			Console.WriteLine($"Number of vehicles in the database: {allVehicles.Count}");

            var ownedCar = await context.RentalVehicles.Where(rv => rv.OwnerId == OwnerID).ToListAsync();
            return ownedCar;
		}
        public async Task AddNewVehicle(RentalVehicle vehicle) {
            
        }
    }
}
