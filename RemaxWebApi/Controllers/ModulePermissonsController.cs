using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulePermissonsController : ControllerBase
    {

        public readonly RelEstDbContext _context;
        public readonly string sp = "[dbo].[Get_All_Modules_Permission]";
        public ModulePermissonsController(RelEstDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetModulePermissons")]
        public List<ModulePermission> AllModulePermissons()
        {
            return _context?.ModulePermissions?.FromSql($"{sp}").ToList();
        }
    }
}
