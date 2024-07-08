using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;

namespace Alef_Academy_Main.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly AlefDbContext _context;

        public EnrollmentsController(AlefDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enrollments.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,CourseId,EnrollmentDate,IsCompleted,CompletionDate")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments.FindAsync(id);
            if (enrollments == null)
            {
                return NotFound();
            }
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,CourseId,EnrollmentDate,IsCompleted,CompletionDate")] Enrollments enrollments)
        {
            if (id != enrollments.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentsExists(enrollments.EnrollmentID))
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
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollments = await _context.Enrollments.FindAsync(id);
            if (enrollments != null)
            {
                _context.Enrollments.Remove(enrollments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentsExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
