using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tenno_Server.Models;

namespace Tenno_Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Models.Warframes model_Warframes = new();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Warframes()
        {
            //ViewData["warframesNum"] = model_Warframes.textNumOfWarframes;
            //return View(model_Warframes.Warframes_units);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}