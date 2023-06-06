using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;
namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleModulePermissonsController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public RoleModulePermissonsController(RelEstDbContext context)
        {
            _context = context;
        }

        /*
        select* from ModulePermissionDetails mpd
        join CodeTypeValues ctv on ctv.CodeTypeShortCode='MODULES' and ctv.ShortCode=mpd.ModuleShortCode
        where ModuleShortCode= 'CodeTypes'
        */

        [HttpGet("{moduleShortCode}", Name = "AllModuleActions")]
        public List<CodeTypeValues> AllModuleActions(string moduleShortCode)
        {
            /*
            var data = (from ctv in _context.CodeTypeValues
                        join mpd in _context.ModulePermissionDetails
                           on new { shortcode = ctv.ShortCode, moduleShortCode = ctv.CodeTypeShortCode }
                           equals new { shortcode = mpd.ModuleShortCode, moduleShortCode = "MODULES" }
                        where mpd.ModuleShortCode == moduleShortCode
                        select new CodeTypeValues
                        {
                            CodeTypeShortCode= ctv.CodeTypeShortCode,
                            ShortCode=ctv.ShortCode,
                            Description=ctv.Description
                        }).ToList();

            return data;
            */
            var data = (from mpd in _context.ModulePermissionDetails 
                        join ctv  in _context.CodeTypeValues
                        on mpd.ModuleShortCode equals ctv.ShortCode   
                        join action in _context.CodeTypeValues
                        on mpd.PermissionShortCode equals action.ShortCode
                        where mpd.ModuleShortCode == moduleShortCode & ctv.CodeTypeShortCode=="MODULES"
                        select new CodeTypeValues
                        {
                            CodeTypeShortCode= moduleShortCode,
                            ShortCode=action.ShortCode,
                            Description=action.Description
                        }).ToList();

            return data;
        }


        [HttpPost]
        public async Task<IActionResult> InsertRoleModulePermissionDetails([FromBody] List<ModuleRolePermissionDetails> lstleadPropertyDetails)
        {
            try
            {
                if (lstleadPropertyDetails!=null && lstleadPropertyDetails.Count>0)
                {
                    List<ModuleRolePermissionDetails> dbroles = _context.ModuleRolePermissionDetails.Where(x => x.RoleShortCode==lstleadPropertyDetails.First().RoleShortCode).ToList();

                    foreach (var roleModulePermissionDetails in lstleadPropertyDetails)
                    {
                        if (dbroles.Where(x=>x.PermissionShortCode==roleModulePermissionDetails.PermissionShortCode
                                            & x.ModuleShortCode==roleModulePermissionDetails.ModuleShortCode
                                            & x.RoleShortCode==roleModulePermissionDetails.RoleShortCode).FirstOrDefault()==null)
                        {
                            roleModulePermissionDetails.CreatedDateTime = DateTime.Now;
                            roleModulePermissionDetails.UpdatedDateTime = DateTime.Now;
                            roleModulePermissionDetails.UpdatedBy="Admin";
                            roleModulePermissionDetails.RoleID=null;
                            roleModulePermissionDetails.CreatedBy="Admin";
                            _context.ModuleRolePermissionDetails.Add(roleModulePermissionDetails);  
                        }                       
                    }

                    foreach (var roleModulePermissionDetails in dbroles)
                    {
                        if (lstleadPropertyDetails.Where(x => x.PermissionShortCode==roleModulePermissionDetails.PermissionShortCode
                                            & x.ModuleShortCode==roleModulePermissionDetails.ModuleShortCode
                                            & x.RoleShortCode==roleModulePermissionDetails.RoleShortCode).FirstOrDefault()==null)
                        {                          
                            _context.ModuleRolePermissionDetails.Remove(roleModulePermissionDetails);
                        }
                    }
                    await _context.SaveChangesAsync(); 
                }
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.Message.Contains("PK_LeadPropertyDetails"))
                {
                    throw new Exception(string.Format("A Record with {0} already exists in Database", "Link Property to Lead"));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
