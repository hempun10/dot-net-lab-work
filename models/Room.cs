namespace myapp.models{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; } // Single, Double, Suite
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public List<Booking> Bookings;
    }

}