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
            var courses = _dbContext.Courses.ToList();
            return View(courses);
        }


        public ActionResult Details(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courses course)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
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
