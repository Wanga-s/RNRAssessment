using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNRAssessment.BusinessLogic;
using RNRAssessment.DAL;
using RNRAssessment.Models;

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

        [HttpGet("BreakdownReference/{BreakdownReference}")]
        [Produces("application/json",Type=typeof(ExistModel))]
        public IActionResult BreakdownReferenceExists(string BreakdownReference)
        {
            ExistModel existModel = new ExistModel();
            existModel.IsExist=_breakdownLogic.BreakdownReferenceExists(BreakdownReference);
            return Ok(existModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetBreakdownById(int id) { 
            Breakdown? breakdown=_breakdownLogic.GetBreakdown(id);
            if(breakdown == null)
            {
                return NotFound();
            }
            return Ok(breakdown);
        }

        [HttpPost("Create")]
        [Produces("application/json",Type=typeof(Breakdown))]
        public IActionResult CreateBreakdown([FromBody] Breakdown breakdown)
        {
            if (_breakdownLogic.BreakdownReferenceExists(breakdown.BreakdownReference))
            {
                return BadRequest();
            }
            Breakdown addedBreakdown=_breakdownLogic.InsertBreakdown(breakdown);
            return Ok(addedBreakdown);
        }

        [HttpPut("Update")]
        [Produces("application/json", Type = typeof(Breakdown))]
        public IActionResult UpdateBreakdown([FromBody] Breakdown breakdown)
        {
            if (!_breakdownLogic.BreakdownExists(breakdown.Id) || !_breakdownLogic.BreakdownReferenceExists(breakdown.BreakdownReference))
            {
                return NotFound();
            }
            _breakdownLogic.Update(breakdown);
            return Ok(breakdown);
        }
    }
}
