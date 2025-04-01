using Microsoft.AspNetCore.Mvc;
using myapp.models;
using myapp.Repositories;

namespace myapp.controller
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _repository;

        public ClassController(IClassRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Class>> Create([FromBody] Class Class)
        {
            var createdProduct = await _repository.CreateAsync(Class);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetById(int id)
        {
            var Class = await _repository.GetByIdAsync(id);
            if (Class == null)
                return NotFound();

            return Ok(Class);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Class Class)
        {
            if (id != Class.Id)
                return BadRequest();

            await _repository.UpdateAsync(Class);
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