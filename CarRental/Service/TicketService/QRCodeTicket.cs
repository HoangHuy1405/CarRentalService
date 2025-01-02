using CarRental.Models.ShareDrive;

namespace CarRental.Service.TicketService {
    public class QRCodeTicket : ITicketStrategy {
        public async Task<Ticket> CreateTicket(PassengerRide passengerRide) {
            var ticket = new Ticket {
                TicketID = Guid.NewGuid().ToString(),
                PassengerName = passengerRide.Passenger.UserName,
                DriverName = passengerRide.DriverRide.Driver.User.UserName,
                StartLocation = passengerRide.StartLocation,
                EndLocation = passengerRide.EndLocation,
                DepartureDate = passengerRide.DepartDate,
                DepartureTime = passengerRide.DepartTime,
				Seats = passengerRide.Seats,
                TotalFee = passengerRide.TotalFee,
                DepositFee = passengerRide.DepositFee,
                TicketDetails = $"Ticket for {passengerRide.Passenger.UserName} from {passengerRide.StartLocation} to {passengerRide.EndLocation}.",
                PassengerID = passengerRide.PassengerID,
                DriverID = passengerRide.DriverRide.DriverID
            };

            var qrCode = await GenerateQRCodeAsync(ticket); // Generate QR code asynchronously
            ticket.QRCode = qrCode;
            Console.WriteLine(ticket.QRCode);
            return ticket;
        }
        private async Task<string> GenerateQRCodeAsync(Ticket ticket) {
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(ticket.TicketID, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);
            using (var bitmap = qrCode.GetGraphic(20)) {
                using (var ms = new MemoryStream()) {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
