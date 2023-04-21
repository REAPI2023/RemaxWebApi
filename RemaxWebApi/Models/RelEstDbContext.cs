using Microsoft.EntityFrameworkCore;

namespace RemaxWebAPI.Models
{
    public class RelEstDbContext : DbContext
    {
        public RelEstDbContext(DbContextOptions<RelEstDbContext> options)
            : base(options)
        {
        }
        public DbSet<Leads> Leads { get; set; }
    }
}
