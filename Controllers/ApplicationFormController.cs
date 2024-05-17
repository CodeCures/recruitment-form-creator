using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentFormCreator.Models;
using TestApp.Data;
using TestApp.DTOs;
using TestApp.Mappers;
using TestApp.Models;

namespace TestApp
{
    [Route("api/applicationforms")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ApplicationFormController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TestApp.Controllers.applicationForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationForm>>> GetApplicationForm()
        {
            return await _context.ApplicationForms.ToListAsync();
        }

        // GET: api/TestApp.Controllers.applicationForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationForm>> GetApplicationForm(Guid id)
        {
            var applicationForm = await _context.ApplicationForms.FindAsync(id);

            if (applicationForm == null)
            {
                return NotFound();
            }

            var applicationFormQuestions = await _context.Questions.Where(q => q.ApplicationFormId == applicationForm.Id).ToListAsync();
            applicationForm.Questions = applicationFormQuestions;

            return applicationForm;
        }


        // GET: api/TestApp.Controllers.applicationForm/5
        [HttpGet("{id}/submissions")]
        public async Task<ActionResult<IEnumerable<ApplicationSubmission>>> GetApplicationFormSubmissions(Guid id)
        {
            var applicationForm = await _context.ApplicationForms.FindAsync(id);

            if (applicationForm == null)
            {
                return NotFound();
            }

            return await _context.ApplicationSubmission.Where(
                q => q.ApplicationFormId == applicationForm.Id
            ).ToListAsync();
        }

        // PUT: api/TestApp.Controllers.applicationForm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationForm(Guid id, ApplicationForm applicationForm)
        {
            if (id != applicationForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationFormExists(id))
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

        // POST: api/TestApp.Controllers.applicationForm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationForm>> PostApplicationForm(CreateApplicationFormRequest request)
        {
            var applicationForm = request.ToApplicationFormModel();

            _context.ApplicationForms.Add(applicationForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationForm", new { id = applicationForm.Id }, applicationForm);
        }

        // POST: api/TestApp.Controllers.applicationForm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost("{id}/questions")]
        // public async Task<ActionResult<ApplicationForm>> PostQestion(Guid id, CreateQuestionRequest request)
        // {
        //     var question = request.ToQuestionTypeModel();

        //     var applicationForm = await _context.ApplicationForms.FindAsync(id);
        //     if (applicationForm == null)
        //     {
        //         return NotFound();
        //     }

        //     applicationForm.Questions.Add(question);

        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetApplicationForm", new { id = applicationForm.Id }, applicationForm);
        // }

        // DELETE: api/TestApp.Controllers.applicationForm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationForm(Guid id)
        {
            var applicationForm = await _context.ApplicationForms.FindAsync(id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            _context.ApplicationForms.Remove(applicationForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationFormExists(Guid id)
        {
            return _context.ApplicationForms.Any(e => e.Id == id);
        }
    }

    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse,
        OpenEnded
    }
}
