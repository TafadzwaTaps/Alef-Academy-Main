using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;

namespace Alef_Academy_Main.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly AlefDbContext _context;
        private readonly ILogger<InternshipsController> _logger;
        private readonly string _fileSavePath;

        public InternshipsController(AlefDbContext context, ILogger<InternshipsController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _fileSavePath = Path.Combine(env.WebRootPath, "cvfiles");
            if (!Directory.Exists(_fileSavePath))
            {
                Directory.CreateDirectory(_fileSavePath);
            }
        }

        // GET: Internships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Internships.ToListAsync());
        }

        // GET: Internships/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Internships internship)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (internship.CvFile != null)
                    {
                        string fileName = Path.GetFileName(internship.CvFile.FileName);
                        string filePath = Path.Combine(_fileSavePath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            internship.CvFile.CopyTo(stream);
                        }
                        internship.cvfilename = fileName;
                    }

                    internship.applicationdate = DateTime.UtcNow;

                    _context.Internships.Add(internship);
                    _context.SaveChanges();

                    return RedirectToAction("ApplicationSucceess,Internship");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while creating the internship: {ex.Message}");
                }
            }

            return View(internship);
        }

        public IActionResult ApplicationSuccess()
        {
            return View();
        }
        

        private bool InternshipsExists(int id)
        {
            return _context.Internships.Any(e => e.applicationid == id);
        }
    }
}
