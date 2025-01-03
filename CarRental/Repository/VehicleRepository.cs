using CarRental.Data;
using CarRental.Models;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository {
        public VehicleRepository(ApplicationDbContext context) : base(context) {

        }

        public async Task<List<Vehicle>> getAllFromId(string OwnerID) {
			var allVehicles = await context.Vehicles.ToListAsync();
			Console.WriteLine($"Number of vehicles in the database: {allVehicles.Count}");

            var ownedCar = await context.Vehicles.Where(rv => rv.OwnerId == OwnerID).ToListAsync();
            return ownedCar;
		}
    }
}
