using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapp.Data;
using myapp.models;

namespace myapp.controller
{
[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly HotelContext _context;

    public RoomsController(HotelContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        return await _context.Rooms.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Room>> AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRooms), new { id = room.Id }, room);
    }

    [HttpGet("guest-bookings/{guestId}")]
    public async Task<ActionResult<IEnumerable<Booking>>> GetGuestBookings(int guestId)
    {
        var bookings = await _context.Bookings
            .Where(b => b.GuestId == guestId)
            .Include(b => b.Room)
            .ToListAsync();

        if (bookings == null) return NotFound();
        return bookings;
    }

}
}