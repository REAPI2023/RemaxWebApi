using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;



namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public UserController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] Users user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", user.Name));
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Users users)
        {
            try
            {
                _context.Users.Update(users);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<int> Delete(long id)
        {
            try
            {
                Users? user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    return await _context.SaveChangesAsync();
                }
                else
                    return -1;                
            }
            catch
            {
                return -1;
            }
        }
    }
}
