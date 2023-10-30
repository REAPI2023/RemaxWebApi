using Microsoft.AspNetCore.Mvc;
using RemaxWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace RemaxWebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CodeTypeValuesController : ControllerBase
    {

        private readonly ILogger _logger;
        public readonly RelEstDbContext _context;
        public CodeTypeValuesController(RelEstDbContext context)
        {
            _context = context;
           // _logger = logger;
        }
        [HttpGet("{codeType}")]
        public async Task<IActionResult> GetDetails(string codeType)
        {
           // _logger.LogInformation("Fetching codeTypevalues information");            
            var product = await _context.CodeTypeValues.Where(m => m.CodeTypeShortCode == codeType).ToListAsync();            
            return Ok(product);
        }
        [HttpPut]       
        public async Task<IActionResult> Edit([FromBody] CodeTypeValues codeTypes)
        {
            try
            {
                _context.CodeTypeValues.Update(codeTypes);
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
                CodeTypeValues? codeTypes = _context.CodeTypeValues.FirstOrDefault(x => x.ShortCode == shortCode);
                if (codeTypes != null)
                {
                    _context.CodeTypeValues.Remove(codeTypes);
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
        public async Task<IActionResult> InsertCodeTypeVlaues([FromBody] CodeTypeValues codeTypevalues)
        {
            try
            {
                _context.CodeTypeValues.Add(codeTypevalues);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", codeTypevalues.ShortCode));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
