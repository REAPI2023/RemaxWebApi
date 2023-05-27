using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class ModulePermission
    {
        [Key]
        [Required]
        public string ModuleShortName { get; set; }
        public string ModuleName { get; set; }       
        public string? Permission { get; set; }

        /*
         TRUNCATE   table ModulePermissionDetails
Insert  into ModulePermissionDetails
select  modules.[ShortCode],CONVERT(NVARCHAR(max),permission.[ShortCode]),SYSDATETIME(),SYSDATETIME(),'Admin',SYSDATETIME()
from CodeTypeValues modules
join CodeTypeValues permission on permission.CodeTypeShortCode='PERMISSIONS'
left join ModulePermissionDetails modper on modper.ModuleShortCode=Modules.ShortCode and modper.Permissionshortcode=permission.ShortCode
where  modules.CodeTypeShortCode in ('MODULES')   and modules.ShortCode not in ('DASHBOARD') and permission.ShortCode not in ('ADD_LEAD_SCHEDULE','LINK_LEAD_PROPERTY')

Insert  into ModulePermissionDetails
select  modules.[ShortCode],CONVERT(NVARCHAR(max),permission.[ShortCode]),SYSDATETIME(),SYSDATETIME(),'Admin',SYSDATETIME()
from CodeTypeValues modules
join CodeTypeValues permission on permission.CodeTypeShortCode='PERMISSIONS'
left join ModulePermissionDetails modper on modper.ModuleShortCode=Modules.ShortCode and modper.Permissionshortcode=permission.ShortCode
where  modules.CodeTypeShortCode in ('MODULES')   and modules.ShortCode  in ('DASHBOARD') 
                                

         */
    }
}
