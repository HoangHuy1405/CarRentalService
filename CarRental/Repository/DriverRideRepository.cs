﻿using CarRental.Data;
using CarRental.Models.DTO;
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
                .ThenInclude(d => d.PassengerRides!)
                .FirstOrDefaultAsync(dr => dr.DriverRideID == id);
        }

        public async Task<List<DriverRideDto>> GetValidDriverRides(PassengerRideView passenger) {
            try {
                var query = context.DriverRides
            .Include(driverRide => driverRide.Driver) // Load related Driver entity
            .ThenInclude(driver => driver.User) // Load related ApplicationUser entity
            .Where(driverRide =>
                driverRide.SeatLeft >= passenger.Seats); // Ensure seats available meet passenger's need

                // Add the DepartDate condition only if passenger.DepartDate is not null
                if (passenger.DepartDate.HasValue) {
                    query = query.Where(driverRide =>
                        driverRide.DepartDate.HasValue && // Ensure DepartDate exists
                        driverRide.DepartDate.Value.Date == passenger.DepartDate.Value.Date); // Match DepartDate with the passenger's date
                }

                var result = await query.Select(driverRide => new DriverRideDto {
                    // DriverRide fields
                    DriverRideID = driverRide.DriverRideID,
                    DriverID = driverRide.DriverID,
                    StartLocation = driverRide.StartLocation,
                    EndLocation = driverRide.EndLocation,
                    DepartDate = driverRide.DepartDate,
                    DepartTime = driverRide.DepartTime,
                    Seats = driverRide.Seats,
                    SeatLeft = driverRide.SeatLeft,

                    // Driver fields
                    DriverName = driverRide.Driver.User.UserName, // From ApplicationUser
                    DriverEmail = driverRide.Driver.User.Email,   // From ApplicationUser
                    DriverPhone = driverRide.Driver.User.PhoneNumber, // From ApplicationUser
                    LicenseNumber = driverRide.Driver.LicenseNumber,
                    LicenseExpiryDate = driverRide.Driver.LicenseExpiryDate,
                    LicenseImageUrl = driverRide.Driver.LicenseImageUrl,
                    NationalIdUrl = driverRide.Driver.NationalIdUrl
                })
                    .ToListAsync();

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"Error while querying DriverRideDtos: {ex.Message}");
                throw;
            }

        }

        public async Task<IEnumerable<DriverRideDto>> GetAllDriverRideByID(string driverID) {
            try {
                var query = context.DriverRides
                        .Include(driverRide => driverRide.Driver) // Load related Driver entity
                        .ThenInclude(driver => driver.User)
                        .Where(driverRide => driverRide.DriverID == driverID);

                var result = await query.Select(driverRide => new DriverRideDto {
                    // DriverRide fields
                    DriverRideID = driverRide.DriverRideID,
                    DriverID = driverRide.DriverID,
                    StartLocation = driverRide.StartLocation,
                    EndLocation = driverRide.EndLocation,
                    DepartDate = driverRide.DepartDate,
                    DepartTime = driverRide.DepartTime,
                    Seats = driverRide.Seats,
                    SeatLeft = driverRide.SeatLeft,

                    // Driver fields
                    DriverName = driverRide.Driver.User.UserName, // From ApplicationUser
                    DriverEmail = driverRide.Driver.User.Email,   // From ApplicationUser
                    DriverPhone = driverRide.Driver.User.PhoneNumber, // From ApplicationUser
                    LicenseNumber = driverRide.Driver.LicenseNumber,
                    LicenseExpiryDate = driverRide.Driver.LicenseExpiryDate,
                    LicenseImageUrl = driverRide.Driver.LicenseImageUrl,
                    NationalIdUrl = driverRide.Driver.NationalIdUrl
                })
                .ToListAsync();

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"Error while querying DriverRideDtos (GetAllDriverRideByID): {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PassengerRideDto>> GetPassRidesOfDriverRide(int driverRideID) {
            Console.WriteLine("driverRideID = " + driverRideID);
            var passengerRides = await context.PassengerRides
                .Where(pr => pr.DriverRideID == driverRideID)  // Filter by driverID
                .Select(pr => new PassengerRideDto {
                    PassengerRideID = pr.PassengerRideID,
                    PassengerName = pr.Passenger != null ? pr.Passenger.UserName : "N/A",
                    StartLocation = pr.StartLocation,
                    EndLocation = pr.EndLocation,
                    Seats = pr.Seats,
                    DepartDate = pr.DepartDate,
                    DepartTime = pr.DepartTime,
                    TotalFee = pr.TotalFee,
                    Status = pr.Status
                })
                .ToListAsync();

            return passengerRides;
        }

    }
}
