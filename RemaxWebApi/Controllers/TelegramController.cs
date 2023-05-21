using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;


namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public TelegramController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpPost("{message}")]
        public async Task<IActionResult> SendMessage(string message)
        {
            try
            {
                
                string bot_Id = "6087752875:AAG0pQrD_qqp6CLx2o1BxvXGalfSB0T_XHY";
                string group_Id = "-1001334352382";
                string url = string.Format("https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}", bot_Id, group_Id, message);
                using var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = client.GetStringAsync(url).Result;
                Console.WriteLine(response);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_CodeTypes"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", "Telegram Message"));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
