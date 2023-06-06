using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;
namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public PermissionsController(RelEstDbContext context)
        {
            _context = context;
        }

        /*
        select* from ModulePermissionDetails mpd
        join CodeTypeValues ctv on ctv.CodeTypeShortCode='MODULES' and ctv.ShortCode=mpd.ModuleShortCode
        where ModuleShortCode= 'CodeTypes'
        */

        [HttpGet("{moduleShortCode}/{roleShortCode}", Name = "AllModulePermissionsbyRole")]
        public List<CodeTypeValues> Allpermissions(string moduleShortCode,string roleShortCode)
        {
            var data = (from mrp in _context.ModuleRolePermissionDetails
                        join ctv in _context.CodeTypeValues
                        on mrp.PermissionShortCode equals ctv.ShortCode                        
                        where mrp.ModuleShortCode == moduleShortCode & ctv.CodeTypeShortCode=="PERMISSIONS" &mrp.RoleShortCode==roleShortCode
                        select new CodeTypeValues
                        {
                            CodeTypeShortCode= moduleShortCode,
                            ShortCode=ctv.ShortCode,
                            Description=ctv.Description
                        }).ToList();

            return data;
        }
        }
}
