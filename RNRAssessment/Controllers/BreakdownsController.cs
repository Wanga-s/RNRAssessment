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
        public async Task<ActionResult<IEnumerable<Breakdown>>> GetBreakdown()
        {
            if (_breakdownContext.Breakdowns == null)
            {
                return NotFound();
            }
            return await _breakdownContext.Breakdowns.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Breakdown>> GetBreakdown(int id)
        {
            if (_breakdownContext.Breakdowns == null)
            {
                return NotFound();
            }
            var employee = await _breakdownContext.Breakdowns.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Breakdown>> PostBreakdown(int id, Breakdown breakdown)
        {
            _breakdownContext.Breakdowns.Add(breakdown);
            await _breakdownContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBreakdown), new { id = breakdown.Id }, breakdown);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBreakdown(int id, Breakdown breakdown)
        {
            if (id != breakdown.Id)
            {
                return BadRequest();
            }

            _breakdownContext.Entry(breakdown).State = EntityState.Modified;
            try
            {
                await _breakdownContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }
    }
}
