using RNRAssessment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNRAssessment.BusinessLogic
{
    public interface IBreakdownLogic
    {
        void InsertBreakdown(Breakdown newBreakdown);
        IEnumerable<Breakdown> GetBreakdowns();
        Breakdown? GetBreakdown(int BreakdownId);
        void Update(Breakdown breakdown);
    }
}
