﻿using CarRental.Models;
using CarRental.Models.DTO;
using CarRental.Models.ShareDrive;

namespace CarRental.Repository
{
    public interface IDriverRideRepository : IRepository<DriverRide> {
        public Task<List<DriverRideDto>> GetValidDriverRides(PassengerRideView passenger);
    }
}
