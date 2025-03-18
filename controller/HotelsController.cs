using Microsoft.AspNetCore.Mvc;
using myapp.models;
using myapp.Repositories;

namespace myapp.controller
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelsController(IHotelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> Create([FromBody] Hotel hotel)
        {
            var createdProduct = await _repository.CreateAsync(hotel);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetById(int id)
        {
            var hotel = await _repository.GetByIdAsync(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.Id)
                return BadRequest();

            await _repository.UpdateAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}