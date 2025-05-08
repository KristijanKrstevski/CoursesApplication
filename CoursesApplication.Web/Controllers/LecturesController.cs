using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Data;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Web.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ILectureService _lectureService;
        private readonly ICourseService _courseService;

        public LecturesController(ILectureService lectureService, ICourseService courseService)
        {
            _lectureService = lectureService;
            _courseService = courseService;
        }

        // GET: Lectures
        public IActionResult Index()
        {
            return View(_lectureService.GetAll());
        }

        // GET: Lectures/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = _lectureService.GetById(id.Value);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_courseService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Date,CourseId")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _lectureService.Insert(lecture);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_courseService.GetAll(), "Id", "Name", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = _lectureService.GetById(id.Value);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_courseService.GetAll(), "Id", "Name", lecture.CourseId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Date,CourseId")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _lectureService.Update(lecture);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.Id))
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
            ViewData["CourseId"] = new SelectList(_courseService.GetAll(), "Id", "Name", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = _lectureService.GetById(id.Value);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _lectureService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(Guid id)
        {
            return _lectureService.GetById(id) != null;
        }
    }
}
