using Microsoft.AspNetCore.Mvc;
using RNRAssessment.UI.Models;
using RNRAssessment.UI.Services;
using System.Diagnostics;

namespace RNRAssessment.UI.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return RedirectToAction("Index","Breakdown");
        }
    }
}
