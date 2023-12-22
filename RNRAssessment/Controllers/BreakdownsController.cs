using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNRAssessment.Models;

namespace RNRAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownsController : ControllerBase
    {
        private readonly BreakdownContext _breakdownContext;

        public BreakdownsController(BreakdownContext breakdownContext) 
        { 
            _breakdownContext = breakdownContext;
        }

        [HttpGet]
        public IActionResult GetBreakdowns()
        {
            var breakdowns = _breakdownContext.Breakdowns.ToList();
            return Ok(breakdowns);
        }

        [HttpPost]
        public IActionResult CreateBreakdown([FromBody] Breakdown breakdown)
        {
            _breakdownContext.Breakdowns.Add(breakdown);
            _breakdownContext.SaveChanges();
            return Ok(breakdown);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBreakdown(int id, [FromBody] Breakdown breakdown)
        {
            var existingBreakdown = _breakdownContext.Breakdowns.Find(id);
            if (existingBreakdown == null)
            {
                return NotFound();
            }

            existingBreakdown.BreakdownReference = breakdown.BreakdownReference;
            existingBreakdown.CompanyName = breakdown.CompanyName;
            existingBreakdown.DriverName = breakdown.DriverName;
            existingBreakdown.RegistrationNumber = breakdown.RegistrationNumber;
            existingBreakdown.BreakdownDate = breakdown.BreakdownDate;

            _breakdownContext.SaveChanges();

            return Ok(existingBreakdown);
        }
    }
}
