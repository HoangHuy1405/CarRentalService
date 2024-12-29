namespace CarRental.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; } // ID of the user
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
