using Microsoft.AspNetCore.Mvc;
using myapp.models;
using myapp.Repositories;

namespace myapp.controller
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create([FromBody] Student student)
        {
            var createdProduct = await _repository.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest();

            await _repository.UpdateAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }


        // // Find who scored the highest score from which class
        // [HttpGet("detail-with-highest-scores")]
        // public async Task<IActionResult> GetClassesWithHighestScore()
        // {
        //     var result = await _context.Classes
        //         .SelectMany(c => c.StudentsToNavigate
        //         .SelectMany(s => s.MarksToNavigate
        //         .Select(m => new
        //         {
        //             c.Name,
        //             s.StudentName,
        //             SubjectName = m.SubjectToNavigate.Name,
        //             Score = m.MarksObtained
        //         })
        //         ))
        //         .ToListAsync();

        //     var highest = result.Where(x => x.Score == result.Max(y => y.Score));

        //     return Ok(highest);
        // }

        // // Order classes based on average class score
        // [HttpGet("classes-with-average-score")]
        // public async Task<IActionResult> GetAllClassesAverageScore()
        // {
        //     var result = await _context.Classes
        //     .Select(c => new
        //     {
        //         c.Name,
        //         AverageScore = c.StudentsToNavigate
        //             .SelectMany(s => s.MarksToNavigate)
        //             .Average(m => (double?)m.MarksObtained) ?? 0
        //     })
        //     .OrderByDescending(c => c.AverageScore)
        //     .ToListAsync(); // Return all classes instead of just one

        //     return Ok(result);
        // }
    }
}