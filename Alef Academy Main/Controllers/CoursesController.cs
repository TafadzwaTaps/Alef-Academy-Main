using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alef_Academy_Main.Database;
using Alef_Academy_Main.Models;
using Microsoft.AspNetCore.Authorization;

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

        public ActionResult Edit(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Courses course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Courses.Update(course);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                _dbContext.Courses.Remove(course);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Search(string courseName, bool isActive, decimal minPrice, decimal maxPrice)
        {
            var courses = _dbContext.Courses.Where(c =>
                (string.IsNullOrEmpty(courseName) || c.CourseName.Contains(courseName)) &&
                c.IsActive == isActive &&
                c.Price >= minPrice &&
                c.Price <= maxPrice).ToList();

            return View(courses);
        }

    
        public ActionResult UpdateStatus(int id, bool isActive)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            course.IsActive = isActive;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
