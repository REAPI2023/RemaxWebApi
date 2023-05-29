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
        [HttpPost]
        public async Task<IActionResult> InsertRoleModulePermissionDetails([FromBody] List<RoleModulePermissionDetails> lstleadPropertyDetails)
        {
            try
            {
                foreach (var roleModulePermissionDetails in lstleadPropertyDetails)
                {
                    roleModulePermissionDetails.CreatedDateTime = DateTime.Now;
                    roleModulePermissionDetails.UpdatedDateTime = DateTime.Now;
                    roleModulePermissionDetails.UpdatedBy="Admin";
                    roleModulePermissionDetails.CreatedBy="Admin";
                    _context.RoleModulePermissionDetails.Add(roleModulePermissionDetails);
                }
                await _context.SaveChangesAsync();
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
