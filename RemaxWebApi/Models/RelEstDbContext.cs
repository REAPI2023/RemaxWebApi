using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
/*
 dotnet ef migrations add Create_5 --project RemaxWebApi
 dotnet ef database update --project RemaxWebApi
 */
namespace RemaxWebAPI.Models
{
    public class RelEstDbContext : DbContext
    {
        public RelEstDbContext(DbContextOptions<RelEstDbContext> options)
            : base(options)
        {
        }
        public DbSet<CodeTypes> CodeTypes { get; set; }
        public DbSet<Leads> Leads
        {
            get; set;
        }
        public DbSet<CodeTypeValues> CodeTypeValues { get; set; }
        public DbSet<CommercialProperty> CommercialProperty { get; set; }
        public DbSet<ResidentialProperty> ResidentialProperty { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<LeadNotes> LeadNotes { get; set; }
        public DbSet<LeadPropertyDetails> LeadPropertyDetails { get; set; }
        public DbSet<ModulePermissionDetails> ModulePermissionDetails { get; set; }
        public DbSet<ModulePermission> ModulePermissions { get; set; }
        public DbSet<RoleModulePermissionDetails> RoleModulePermissionDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ModuleRolePermissionDetails> ModuleRolePermissionDetails { get; set; }

        
    }
}
