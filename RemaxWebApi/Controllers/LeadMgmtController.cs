using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebAPI.Models;
using System.Text.Json;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadMgmtController : ControllerBase
    {
        private readonly ILogger _logger;
        public readonly RelEstDbContext _context;
        public LeadMgmtController(RelEstDbContext context, ILogger<LeadMgmtController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: RemaxLeadMgmtController
        [HttpGet(Name = "GetLeadDetails")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Leads.ToListAsync());
        }


        // GET: RemaxLeadMgmtController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            _logger.LogInformation("Fetching Lead information");
            //if (id < 1)
            //    return BadRequest();
            var product = await _context.Leads.FirstOrDefaultAsync(m => m.LeadId == id);
            //if (product == null)
            //    return NotFound();
            return Ok(product);
        }
        [HttpGet("{email}/{role}")]
        public async Task<IActionResult> GetLeadsByUser(string email, string role)
        {

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Email == email);
            if (user != null)
            {
                _logger.LogInformation("Fetching Lead information");
                if (user.Role!=null && !user.Role.Contains("Admin"))
                {
                    var product = await _context.Leads.Where(m => m.UserId == user.Id).ToListAsync();
                    return Ok(product);
                }
                else
                {
                    var product = await _context.Leads.ToListAsync();
                    return Ok(product);
                }
            }
            else
            {
                return Ok(new List<Leads>());
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<int?> Create(Leads collection)
        {

            _logger.LogInformation($"Adding Leads Collection :{JsonSerializer.Serialize(collection)} ");
            _context.Leads.Add(collection);
            return await _context.SaveChangesAsync();


        }
        //// POST: RemaxLeadMgmtController/Edit/5
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<int> Edit([FromBody] Leads lead)
        {
            _logger.LogInformation($"Editing leads :{JsonSerializer.Serialize(lead)} ");
            _context.Leads.Update(lead);
            return await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

        }

        //// GET: RemaxLeadMgmtController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RemaxLeadMgmtController/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<int> Delete(int id)
        {

            Leads? lead = _context.Leads.FirstOrDefault(x => x.LeadId == id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                return await _context.SaveChangesAsync();
            }
            else
                return -1;

            //return RedirectToAction(nameof(Index));

        }


    }
}
