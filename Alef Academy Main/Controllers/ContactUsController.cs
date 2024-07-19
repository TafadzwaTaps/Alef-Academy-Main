using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;
using System.Net.Mail;
using System.Net;

namespace Alef_Academy_Main.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly AlefDbContext _context;
        private readonly IConfiguration _configuration;

        public ContactUsController(AlefDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactUs.ToListAsync());
        }

        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.InquiryId == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Message,InquiryDate")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.InquiryDate = DateTime.Now;
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }
    }
}
