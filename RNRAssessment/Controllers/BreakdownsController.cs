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
        public IActionResult GetBreakdowns()
        {
            IEnumerable<Breakdown> breakdowns = _breakdownLogic.GetBreakdowns();
            return Ok(breakdowns);
        }

        [HttpPost]
        public IActionResult CreateBreakdown([FromBody] Breakdown breakdown)
        {
            _breakdownLogic.InsertBreakdown(breakdown);
            return Ok(breakdown);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBreakdown(int id, [FromBody] Breakdown breakdown)
        {
            var existingBreakdown = _breakdownLogic.GetBreakdown(id);
            if (existingBreakdown == null)
            {
                return NotFound();
            }

            _breakdownLogic.Update(breakdown);

            return Ok(existingBreakdown);
        }
    }
}
