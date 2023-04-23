using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;



namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeTypesController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public CodeTypesController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetCodeTypesDetails")]
        public async Task<IActionResult> AllCodeTypesDetails()
        {
            return Ok(await _context.CodeTypes.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertCodeType([FromBody] CodeTypes codeTypes)
        {
            try
            {
                _context.CodeTypes.Add(codeTypes);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", codeTypes.ShortCode));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
