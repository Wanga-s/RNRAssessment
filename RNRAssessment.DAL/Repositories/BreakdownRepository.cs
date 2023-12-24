using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNRAssessment.DAL
{
    public class BreakdownRepository : GenericRepository<Breakdown>,IBreakdownRepository
    {
        public BreakdownRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
