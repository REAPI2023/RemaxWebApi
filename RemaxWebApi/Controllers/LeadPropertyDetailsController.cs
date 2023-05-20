using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadPropertyDetailsController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public LeadPropertyDetailsController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetLeadPropertyDetails")]
        public async Task<IActionResult> GetLeadPropertyDetails()
        {
            return Ok(await _context.LeadPropertyDetails.ToListAsync());
        }
        [HttpGet("{leadId}", Name = "GetLeadPropertyDetailsbyLeadID")]
        public async Task<IActionResult> GetAllLeadPropertyDetailsbyLeadID(int leadId)
        {
            return Ok(await _context.LeadPropertyDetails.Where(x => x.LeadId==leadId).OrderByDescending(x => x.LeadPropertyID).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> InsertCodeType([FromBody] LeadPropertyDetails leadPropertyDetails)
        {
            try
            {
                leadPropertyDetails.CreatedDateTime = DateTime.Now;
                leadPropertyDetails.UpdatedDateTime = DateTime.Now;
                leadPropertyDetails.UpdatedBy="Admin";
                leadPropertyDetails.CreatedBy="Admin";
                _context.LeadPropertyDetails.Add(leadPropertyDetails);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_LeadPropertyDetails"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", leadPropertyDetails.PropertyId));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
