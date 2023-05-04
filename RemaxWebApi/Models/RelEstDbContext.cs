using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;

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
    }
}
