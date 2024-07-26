using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;

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
            return View(await _context.contactus.ToListAsync());
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,email,message,inquirydate")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.inquirydate = DateTime.Now;
                _context.Add(contactUs);
                await _context.SaveChangesAsync();

                // Send email
                await SendEmail(contactUs);

                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        private async Task SendEmail(ContactUs contactUs)
        {
            var smtpSettings = _configuration.GetSection("SMTP");
            var smtpClient = new SmtpClient(smtpSettings["Server"])
            {
                Port = int.Parse(smtpSettings["Port"]),
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings["From"]),
                Subject = "New Contact Inquiry",
                Body = $"<h3>New Inquiry from {contactUs.name}</h3><p>Email: {contactUs.email}</p><p>Message: {contactUs.message}</p><p>Date: {contactUs.inquirydate}</p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add("info@alefacademy.com");

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
