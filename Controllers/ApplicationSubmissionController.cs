using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentFormCreator.Models;
using TestApp.Data;

namespace TestApp.Controllers
{
    [Route("api/applicationsubmissions")]
    [ApiController]
    public class ApplicationSubmissionController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ApplicationSubmissionController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationSubmission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationSubmission>>> GetApplicationSubmission()
        {
            return await _context.ApplicationSubmission.ToListAsync();
        }

        // GET: api/ApplicationSubmission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationSubmission>> GetApplicationSubmission(Guid id)
        {
            var applicationSubmission = await _context.ApplicationSubmission.FindAsync(id);

            if (applicationSubmission == null)
            {
                return NotFound();
            }

            return applicationSubmission;
        }

        // PUT: api/ApplicationSubmission/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationSubmission(Guid id, ApplicationSubmission applicationSubmission)
        {
            if (id != applicationSubmission.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationSubmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationSubmissionExists(id))
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

        // POST: api/ApplicationSubmission
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationSubmission>> PostApplicationSubmission(ApplicationSubmission applicationSubmission)
        {
            _context.ApplicationSubmission.Add(applicationSubmission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationSubmission", new { id = applicationSubmission.Id }, applicationSubmission);
        }

        // DELETE: api/ApplicationSubmission/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationSubmission(Guid id)
        {
            var applicationSubmission = await _context.ApplicationSubmission.FindAsync(id);
            if (applicationSubmission == null)
            {
                return NotFound();
            }

            _context.ApplicationSubmission.Remove(applicationSubmission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationSubmissionExists(Guid id)
        {
            return _context.ApplicationSubmission.Any(e => e.Id == id);
        }
    }
}
