using Microsoft.EntityFrameworkCore;

namespace Cumulative2N01605244.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
