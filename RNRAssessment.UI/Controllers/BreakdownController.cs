using Microsoft.AspNetCore.Mvc;
using RNRAssessment.UI.Models;
using RNRAssessment.UI.Services;

namespace RNRAssessment.UI.Controllers
{
    public class BreakdownController : Controller
    {
        private readonly IBreakdownService _breakdownService;

        public BreakdownController(IBreakdownService breakdownService)
        {
            _breakdownService = breakdownService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BreakdownModel>? breakdownModels = await _breakdownService.GetBreakdownsAsync();
            return View(breakdownModels);
        }

        public async Task<JsonResult> CheckForBreakdownReference(string BreakdownReference,int Id)
        {
            ExistModel? existModel = await _breakdownService.BreakdownReferenceExistsAsync(BreakdownReference);
            if(existModel!=null && existModel.IsExist && Id==0)
            {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult Create()
        {
            BreakdownModel breakdownModel= new BreakdownModel();    
            return View(breakdownModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BreakdownModel model)
        {
            if (ModelState.IsValid)
            {
                await _breakdownService.CreateBreakdownsAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            BreakdownModel? breakdown=await _breakdownService.GetBreakdownAsync(id);
            return View(breakdown);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BreakdownModel model)
        {
            if (ModelState.IsValid)
            {
                await _breakdownService.UpdateBreakdownsAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
