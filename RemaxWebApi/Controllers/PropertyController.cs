using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace RemaxWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public PropertyController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "PropertyDetails")]
        public async Task<IActionResult> AllPropertyDetails()
        {
            return Ok(await _context.ResidentialProperty.OrderByDescending(x => x.PropertyId).ToListAsync());
        }
        [HttpGet("{propertyId}", Name = "PropertyDetailsbyID")]
        public async Task<IActionResult> AllLeadNotessDetails(int propertyID)
        {
            return Ok(await _context.ResidentialProperty.Where(x => x.PropertyId==propertyID).OrderByDescending(x => x.PropertyId).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertCodeType([FromBody] ResidentialProperty residentialProperty)
        {
            try
            {
                /*
                leadNotes.CreatedDateTime = DateTime.Now;
                leadNotes.UpdatedDateTime = DateTime.Now;
                leadNotes.UpdatedBy="Admin";
                leadNotes.CreatedBy="Admin";
                */
                _context.ResidentialProperty.Add(residentialProperty);
                await _context.SaveChangesAsync();
                TelegramController tc = new TelegramController(_context);
                await tc.SendMessage(string.Format("New Property Added . Property name : {0} with Property ID :-{1}", residentialProperty.PropertyName,residentialProperty.PropertyId));
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", residentialProperty.PropertyId));
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ResidentialProperty residentialProperty)
        {
            try
            {
                _context.ResidentialProperty.Update(residentialProperty);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{propertyId}")]
        public async Task<int> Delete(int propertyId)
        {
            try
            {
                ResidentialProperty? residentialProperty = _context.ResidentialProperty.FirstOrDefault(x => x.PropertyId == propertyId);
                if (residentialProperty != null)
                {
                    _context.ResidentialProperty.Remove(residentialProperty);
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
