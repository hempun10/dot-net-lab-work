using Microsoft.AspNetCore.Mvc;
using myapp.models;

namespace myapp.controller
{
    [ApiController]
    [Route("HotelDetails")]
    public class HotelDetailsController : Controller
    {
         public static List<HotelDetails> HotelDetails = new List<HotelDetails>();


        /// <summary>
        /// Retrieves a list of hotels based on optional filters.
        /// </summary>
        /// <param name="name">Optional name filter</param>
        /// <param name="phone">Optional phone filter</param>
        /// <param name="address">Optional address filter</param>
        /// <returns>List of hotel details</returns>
        [HttpGet]
        public ActionResult<IEnumerable<HotelDetails>> Get([FromQuery] string? name, [FromQuery] string? phone, [FromQuery] string? address)
        {
            var query = HotelDetails.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(h => h.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(phone))
                query = query.Where(h => h.PhonNumber.Contains(phone));

            if (!string.IsNullOrWhiteSpace(address))
                query = query.Where(h => h.Address.Contains(address));

            return Ok(query.ToList());
        }

        // GET api/<HotelDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<HotelDetails> Get(int id)
        {
            var hotelDetails = HotelDetails.FirstOrDefault((e) => e.Id == id);

            if(hotelDetails == null)
            {
                return NotFound("hotelDetails not found");

            }

            return hotelDetails;

        }

        // POST api/<HotelDetailsController>
        [HttpPost]
        public void Post([FromBody] HotelDetails value)
        {
            HotelDetails.Add(value);
        }

        // PUT api/<HotelDetailsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] HotelDetails value)
        {
            var Hotel = HotelDetails.FirstOrDefault(s => s.Id == id);

            if(Hotel == null)
            {
                return NotFound("Hotel not found");
            }
            Hotel.Name = value.Name;
            Hotel.Address = value.Address;
            Hotel.PhonNumber = value.PhonNumber;

            return Ok("Hotel Updated Sucessfully");
        }

        // DELETE api/<HotelDetailsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = HotelDetails.FirstOrDefault(s => s.Id == id);
            if (hotel == null)
            {
                return NotFound(new { message = "hotel not found" });
            }

            HotelDetails.Remove(hotel);
            return Ok(new { message = "hotel deleted successfully" });

        }
    }
}

