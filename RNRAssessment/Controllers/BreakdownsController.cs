using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNRAssessment.BusinessLogic;
using RNRAssessment.DAL;

namespace RNRAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownsController : ControllerBase
    {
        private readonly IBreakdownLogic _breakdownLogic;

        public BreakdownsController(IBreakdownLogic breakdownLogic)
        {
            _breakdownLogic = breakdownLogic;
        }

        [HttpGet]
        [Produces("application/json",Type =typeof(IEnumerable<Breakdown>))]
        public IActionResult GetBreakdowns()
        {
            IEnumerable<Breakdown> breakdowns = _breakdownLogic.GetBreakdowns();
            return Ok(breakdowns);
        }

        [HttpPost("Create")]
        [Produces("application/json",Type=typeof(Breakdown))]
        public IActionResult CreateBreakdown([FromBody] Breakdown breakdown)
        {
            Breakdown addedBreakdown=_breakdownLogic.InsertBreakdown(breakdown);
            return Ok(addedBreakdown);
        }

        [HttpPut("Update")]
        [Produces("application/json", Type = typeof(Breakdown))]
        public IActionResult UpdateBreakdown([FromBody] Breakdown breakdown)
        {
            if (!_breakdownLogic.BreakdownExists(breakdown.Id))
            {
                return NotFound();
            }
            _breakdownLogic.Update(breakdown);
            return Ok(breakdown);
        }
    }
}
