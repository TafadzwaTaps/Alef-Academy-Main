using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;

namespace Alef_Academy_Main.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly AlefDbContext _context;

        public InstructorsController(AlefDbContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.ToListAsync());
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructors = await _context.Instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructors == null)
            {
                return NotFound();
            }

            return View(instructors);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorsName,Bio,ContactEmail")] Instructors instructors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructors);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructors = await _context.Instructors.FindAsync(id);
            if (instructors == null)
            {
                return NotFound();
            }
            return View(instructors);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorsName,Bio,ContactEmail")] Instructors instructors)
        {
            if (id != instructors.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorsExists(instructors.InstructorId))
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
            return View(instructors);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructors = await _context.Instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructors == null)
            {
                return NotFound();
            }

            return View(instructors);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructors = await _context.Instructors.FindAsync(id);
            if (instructors != null)
            {
                _context.Instructors.Remove(instructors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorsExists(int id)
        {
            return _context.Instructors.Any(e => e.InstructorId == id);
        }
    }
}
