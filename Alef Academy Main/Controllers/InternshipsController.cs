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
    public class InternshipsController : Controller
    {
        private readonly AlefDbContext _context;

        public InternshipsController(AlefDbContext context)
        {
            _context = context;
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

            var internship = await _context.Internships
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // GET: Internships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,Position,Name,Email,CvFileName,PortfolioLink,IsAwareOfUnpaid,IsAvailableASAP,IsCommitToThreeMonths,IsAwareOfCommitment,ApplicationDate")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var internship = await _context.Internships.FindAsync(id);
            if (internship == null)
            {
                return NotFound();
            }
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,Position,Name,Email,CvFileName,PortfolioLink,IsAwareOfUnpaid,IsAvailableASAP,IsCommitToThreeMonths,IsAwareOfCommitment,ApplicationDate")] Internship internship)
        {
            if (id != internship.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternshipExists(internship.ApplicationId))
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
            return View(internship);
        }

        // GET: Internships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internship = await _context.Internships
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }

            return View(internship);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship != null)
            {
                _context.Internships.Remove(internship);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternshipExists(int id)
        {
            return _context.Internships.Any(e => e.ApplicationId == id);
        }
    }
}
