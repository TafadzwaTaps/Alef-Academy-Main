using Alef_Academy_Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alef_Academy_Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string lang = "en")
        {
            if (lang == "pl")
            {
                return View("IndexPolish");
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
 
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult CookiePolicy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
