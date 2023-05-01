using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadNotesController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public LeadNotesController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "LeadNotesDetails")]
        public async Task<IActionResult> AllLeadNotessDetails()
        {
            return Ok(await _context.LeadNotes.OrderByDescending(x=>x.CreatedDateTime).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertCodeType([FromBody] LeadNotes leadNotes)
        {
            try
            {
                leadNotes.CreatedDateTime = DateTime.Now;
                leadNotes.UpdatedDateTime = DateTime.Now;
                leadNotes.UpdatedBy="Admin";
                leadNotes.CreatedBy="Admin";
                _context.LeadNotes.Add(leadNotes);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", leadNotes.ID));
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] LeadNotes leadNotes)
        {
            try
            {
                _context.LeadNotes.Update(leadNotes);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{shortCode}")]
        public async Task<int> Delete(string shortCode)
        {
            try
            {
                CodeTypes? codeTypes = _context.CodeTypes.FirstOrDefault(x => x.ShortCode == shortCode);
                if (codeTypes != null)
                {
                    _context.CodeTypes.Remove(codeTypes);
                    return await _context.SaveChangesAsync();
                }
                else
                    return -1;

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return -1;
            }
        }
    }
}
