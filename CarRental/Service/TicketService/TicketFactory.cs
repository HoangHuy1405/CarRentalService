using CarRental.Models.ShareDrive;

namespace CarRental.Service.TicketService {
    public class TicketFactory {
        private readonly ITicketStrategy _ticketStrategy;

        public TicketFactory(ITicketStrategy ticketStrategy) {
            _ticketStrategy = ticketStrategy;
        }

        public async Task<Ticket> CreateTicket(PassengerRide passengerRide) {
            return await _ticketStrategy.CreateTicket(passengerRide);
        }
    }
}
