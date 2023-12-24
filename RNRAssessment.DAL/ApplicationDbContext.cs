using Microsoft.EntityFrameworkCore;

namespace RNRAssessment.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Breakdown> Breakdowns { get; set; }
    }
}
