
using Microsoft.EntityFrameworkCore;
using myapp.models;

namespace myapp.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId);

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = "101", Type = "Single", PricePerNight = 100, IsAvailable = true },
                new Room { Id = 2, RoomNumber = "102", Type = "Double", PricePerNight = 150, IsAvailable = true }
             );

            modelBuilder.Entity<Guest>().HasData(
                new Guest { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "1234567890" }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking 
                { 
                    Id = 1, RoomId = 1, GuestId = 1, 
                    CheckInDate = new DateTime(2024, 9, 1), 
                    CheckOutDate = new DateTime(2024, 9, 5), 
                    TotalPrice = 400 
                }
            );
        }
    }
}
