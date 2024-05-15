using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentFormCreator.DTOs;
using RecruitmentFormCreator.Mappers;
using TestApp.Data;
using TestApp.DTOs;
using TestApp.Helpers;
using TestApp.Mappers;
using TestApp.Models;

namespace TestApp
{
    [Route("api/programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProgramController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TestApp.Controllers.Program
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppProgram>>> GetProgram()
        {
            return await _context.Programs.ToListAsync();
        }

        // GET: api/TestApp.Controllers.Program/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppProgram>> GetProgram(Guid id)
        {
            var program = await _context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        // PUT: api/TestApp.Controllers.Program/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(Guid id, AppProgram program)
        {
            if (id != program.Id)
            {
                return BadRequest();
            }

            _context.Entry(program).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestApp.Controllers.Program
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppProgram>> PostProgram(CreateProgramRequest request)
        {
            var program = request.ToProgramModel();

            _context.Programs.Add(program);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgram", new { id = program.Id }, program);
        }

        // POST: api/TestApp.Controllers.Program
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/questions")]
        public async Task<ActionResult<AppProgram>> PostQestion(Guid id, CreateQuestionRequest request)
        {
            var question = request.ToQuestionTypeModel();

            var program = await _context.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            program.Questions.Add(question);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgram", new { id = program.Id }, program);
        }

        // DELETE: api/TestApp.Controllers.Program/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(program);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramExists(Guid id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }

    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse,
        OpenEnded
    }
}
