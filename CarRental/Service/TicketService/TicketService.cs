
using CarRental.Data;
using CarRental.Models.ShareDrive;
using CarRental.Repository;

namespace CarRental.Service.TicketService {
    public class TicketService {
        private readonly TicketRepository ticketRepo;
        public TicketService(ApplicationDbContext context) {
            ticketRepo = new TicketRepository(context);
        }
        public async Task<Ticket> GenerateTicketAsync(PassengerRide passengerRide, ITicketStrategy pdfTicketStrategy, ITicketStrategy qrCodeTicketStrategy) {
            try {
                Ticket pdfTicket = await pdfTicketStrategy.CreateTicket(passengerRide);
                Ticket qrCodeTicket = await qrCodeTicketStrategy.CreateTicket(passengerRide);
                pdfTicket.QRCode = qrCodeTicket.QRCode;
                await ticketRepo.Add(pdfTicket);

                return pdfTicket;
            } catch (Exception ex) {
                // Handle exception (log it, rethrow it, etc.)
                Console.WriteLine($"Error generating tickets: {ex.Message}");
                throw;
            }
        }
    }
}
