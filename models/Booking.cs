using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.models{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CheckInDate { get; set; }
        
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
    }

}