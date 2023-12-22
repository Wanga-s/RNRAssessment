using Microsoft.EntityFrameworkCore;

namespace RNRAssessment.Models
{
    public class BreakdownContext : DbContext
    {
        public BreakdownContext(DbContextOptions<BreakdownContext> options) : base(options) 
        {

        }
        public DbSet<Breakdown> Breakdowns { get; set; }
    }
}
