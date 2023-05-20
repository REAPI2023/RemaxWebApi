using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
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
    }
}
