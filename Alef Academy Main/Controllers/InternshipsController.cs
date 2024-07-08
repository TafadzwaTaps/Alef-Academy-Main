using Microsoft.AspNetCore.Mvc;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;
using Microsoft.AspNetCore.Authorization;

namespace Alef_Academy_Main.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly AlefDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InternshipsController(AlefDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            var internships = _dbContext.Internships.ToList();
            return View(internships);
        }

        public ActionResult Details(int id)
        {
            var internship = _dbContext.Internships.FirstOrDefault(i => i.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }
            return View(internship);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Internship internship)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string cvFilesPath = Path.Combine(wwwRootPath, "cvfiles");

                // Ensure the cvfiles directory exists
                if (!Directory.Exists(cvFilesPath))
                {
                    Directory.CreateDirectory(cvFilesPath);
                }

             
                    if (internship.CvFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(internship.CvFile.FileName);
                        string extension = Path.GetExtension(internship.CvFile.FileName);
                        internship.CvFileName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(cvFilesPath, fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            internship.CvFile.CopyTo(fileStream);
                        }
                    }

                internship.ApplicationDate = DateTime.Now;

                _dbContext.Internships.Add(internship);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
     
            }
            return View(internship);
        }

            public ActionResult Edit(int id)
        {
            var internship = _dbContext.Internships.FirstOrDefault(i => i.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }
            return View(internship);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Internship internship)
        {
            if (id != internship.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Internships.Update(internship);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(internship);
        }

        public ActionResult Delete(int id)
        {
            var internship = _dbContext.Internships.FirstOrDefault(i => i.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }
            return View(internship);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var internship = _dbContext.Internships.FirstOrDefault(i => i.ApplicationId == id);
            if (internship != null)
            {
                _dbContext.Internships.Remove(internship);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Search(string position, bool isAvailableASAP, bool isAwareOfUnpaid)
        {
            var internships = _dbContext.Internships.Where(i =>
                (string.IsNullOrEmpty(position) || i.Position.Contains(position)) &&
                i.IsAvailableASAP == isAvailableASAP &&
                i.IsAwareOfUnpaid == isAwareOfUnpaid).ToList();

            return View(internships);
        }

        public ActionResult UpdateStatus(int id, bool isCommitToThreeMonths)
        {
            var internship = _dbContext.Internships.FirstOrDefault(i => i.ApplicationId == id);
            if (internship == null)
            {
                return NotFound();
            }

            internship.IsCommitToThreeMonths = isCommitToThreeMonths;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
