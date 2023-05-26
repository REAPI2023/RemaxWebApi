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

            List<int> leadIdList = new List<int>();
            leadIdList= new List<int>(_context.LeadPropertyDetails.Where(x => x.LeadId==leadId).Select(y => y.PropertyId));
            return Ok(await _context.ResidentialProperty.Where(x => leadIdList.Contains(x.PropertyId)).OrderByDescending(x => x.PropertyId).ToListAsync());
        }
        [HttpDelete]
        public async Task<int> Delete([FromBody] LeadPropertyDetails leadPropertyDetails)
        {
            try
            {
                LeadPropertyDetails? codeTypes = _context.LeadPropertyDetails.FirstOrDefault(x => x.LeadId == leadPropertyDetails.LeadId && x.PropertyId==leadPropertyDetails.PropertyId);
                if (codeTypes != null)
                {
                    _context.LeadPropertyDetails.Remove(codeTypes);
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
        [HttpPost]
        public async Task<IActionResult> InsertLeadPropertyDetails([FromBody] List<LeadPropertyDetails> lstleadPropertyDetails)
        {
            try
            {
                foreach (var leadPropertyDetails in lstleadPropertyDetails)
                {
                    leadPropertyDetails.CreatedDateTime = DateTime.Now;
                    leadPropertyDetails.UpdatedDateTime = DateTime.Now;
                    leadPropertyDetails.UpdatedBy="Admin";
                    leadPropertyDetails.CreatedBy="Admin";
                    _context.LeadPropertyDetails.Add(leadPropertyDetails);
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_LeadPropertyDetails"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", "Link Property to Lead"));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
