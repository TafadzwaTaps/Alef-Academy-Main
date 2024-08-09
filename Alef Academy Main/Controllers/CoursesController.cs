using Microsoft.AspNetCore.Mvc;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;

namespace Alef_Academy_Main.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AlefDbContext _dbContext;

        public CoursesController(AlefDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Coding()
        {
            return View();
        }

        public IActionResult Maths()
        {
            return View();
        }

        public IActionResult Science()
        {
            return View();
        }

        public IActionResult Business()
        {
            return View();
        }

        public IActionResult LanguageStudies()
        {
            return View();
        }

        public IActionResult ArtAndDesign()
        {
            return View();
        }
    }
}
