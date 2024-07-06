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
    public class AdministrativeUsersController : Controller
    {
        private readonly AlefDbContext _context;

        public AdministrativeUsersController(AlefDbContext context)
        {
            _context = context;
        }

        // GET: AdministrativeUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdministrativeUsers.ToListAsync());
        }

        // GET: AdministrativeUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers
                .FirstOrDefaultAsync(m => m.AdminUserId == id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }

            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministrativeUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminUserId,AdminUserName,AdminPassword,AdminEmail")] AdministrativeUsers administrativeUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativeUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers.FindAsync(id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }
            return View(administrativeUsers);
        }

        // POST: AdministrativeUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminUserId,AdminUserName,AdminPassword,AdminEmail")] AdministrativeUsers administrativeUsers)
        {
            if (id != administrativeUsers.AdminUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativeUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativeUsersExists(administrativeUsers.AdminUserId))
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
            return View(administrativeUsers);
        }

        // GET: AdministrativeUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUsers = await _context.AdministrativeUsers
                .FirstOrDefaultAsync(m => m.AdminUserId == id);
            if (administrativeUsers == null)
            {
                return NotFound();
            }

            return View(administrativeUsers);
        }

        // POST: AdministrativeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrativeUsers = await _context.AdministrativeUsers.FindAsync(id);
            if (administrativeUsers != null)
            {
                _context.AdministrativeUsers.Remove(administrativeUsers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativeUsersExists(int id)
        {
            return _context.AdministrativeUsers.Any(e => e.AdminUserId == id);
        }
    }
}
