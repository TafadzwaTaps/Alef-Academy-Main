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

        // GET: Internships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internships = await _context.Internships
                .FirstOrDefaultAsync(m => m.applicationid == id);
            if (internships == null)
            {
                return NotFound();
            }

            return View(internships);
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

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while creating the internship: {ex.Message}");
                }
            }

            return View(internship);
        }


        // GET: Internships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internships = await _context.Internships.FindAsync(id);
            if (internships == null)
            {
                return NotFound();
            }
            return View(internships);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("applicationid,position,name,email,cvfilename,cvfiledata,portfoliolink,isawareofunpaid,isavailableasap,iscommittothreemonths,isawareofcommitment,applicationdate")] Internships internships)
        {
            if (id != internships.applicationid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internships);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternshipsExists(internships.applicationid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(internships);
        }

        // GET: Internships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internships = await _context.Internships
                .FirstOrDefaultAsync(m => m.applicationid == id);
            if (internships == null)
            {
                return NotFound();
            }

            return View(internships);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var internships = await _context.Internships.FindAsync(id);
            if (internships != null)
            {
                _context.Internships.Remove(internships);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternshipsExists(int id)
        {
            return _context.Internships.Any(e => e.applicationid == id);
        }
    }
}
