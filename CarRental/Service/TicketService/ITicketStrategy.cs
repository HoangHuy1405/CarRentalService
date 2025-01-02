using CarRental.Models.ShareDrive;

namespace CarRental.Service.TicketService {
    public interface ITicketStrategy {
        Task<Ticket> CreateTicket(PassengerRide passengerRide);
    }
}
