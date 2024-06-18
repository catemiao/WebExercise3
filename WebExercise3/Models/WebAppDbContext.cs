using Microsoft.EntityFrameworkCore;

namespace WebExercise3.Models
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options) { }

        public DbSet<WebExercise3.Models.Member> Member { get; set; }
    }
}
