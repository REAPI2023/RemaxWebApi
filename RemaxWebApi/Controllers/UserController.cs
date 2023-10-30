using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Interfaces;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;



namespace RemaxWebApi.Controllers
{
        //[Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly IJwtAuth jwtAuth;
            private readonly RelEstDbContext _context;
    
            public UserController(IJwtAuth jwtAuth,RelEstDbContext context)
            {
                this.jwtAuth = jwtAuth;
                this._context = context;
            }
            // GET: api/<UserController>
            [HttpGet]
            public IEnumerable<Users> AllUsers()
            {
                return _context.Users;
            }

            // GET api/<UserController>/5
            [HttpGet("emailId")]
            public async Task<IActionResult> UsersByid(string emailId)
            {
            if (_context.Users.Any(x => x.Email == emailId))
                return Ok(await _context.Users.FirstAsync(x => x.Email == emailId));
            else
                return BadRequest();    
            }

            [AllowAnonymous]
            // POST api/<UserController>
            [HttpPost("authentication")]
            public IActionResult Authentication([FromBody] string email)
            {
                var token = jwtAuth.Authentication(email);
                if (token == null)
                    return Unauthorized();
                return Ok(token);
            }


        }
    

}
