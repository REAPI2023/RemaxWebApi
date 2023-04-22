using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
