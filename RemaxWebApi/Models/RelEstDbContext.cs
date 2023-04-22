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
    }
}
