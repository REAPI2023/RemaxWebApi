using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;
namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        public readonly RelEstDbContext _context;
        public ScheduleController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetScheduleDetails")]
        public async Task<IActionResult> AllCodeTypesDetails()
        {
            return Ok(await _context.Schedule.ToListAsync());
        }
        [HttpGet("{leadId}", Name = "LeadSchedulesDetailsbyID")]
        public async Task<IActionResult> AllLeadSchdulesDetails(int leadId)
        {
            return Ok(await _context.Schedule.Where(x => x.LeadId==leadId).OrderByDescending(x => x.CreatedDateTime).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertSchedule([FromBody] Schedule schedule)
        {
            try
            {
                schedule.CreatedDateTime=DateTime.Now;
                schedule.UpdatedDateTime=DateTime.Now;
                _context.Schedule.Add(schedule);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", schedule.LeadId));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
