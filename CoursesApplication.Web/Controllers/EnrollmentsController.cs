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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CoursesApplication.Service.Implementation;

namespace CoursesApplication.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IExamSessionService _examSessionService;
        

        public EnrollmentsController(IStudentService studentService, IEnrollmentService enrollmentService, IExamSessionService examSessionService)
        {
            _studentService = studentService;
            _enrollmentService = enrollmentService;
            _examSessionService = examSessionService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_enrollmentService.GetAllByUser(userId));
        }


        // GET: Enrollments/Create/CourseId
        [Authorize]
        public IActionResult Create(Guid courseId)
        {
            ViewData["CourseId"] = courseId;
            ViewData["StudentId"] = new SelectList(_studentService.GetAll(), "Id", "Index");
            return View();
        }

        // POST: Enrollments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,DateEnrolled,ReEnrolled,StudentId,CourseId")] Enrollment enrollment)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _enrollmentService.EnrollStudentOnCourse(enrollment.StudentId, enrollment.CourseId, userId, enrollment.ReEnrolled);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            // TODO: Implement method
            //throw new NotImplementedException();
           _enrollmentService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("CreateExamSession")]
        public IActionResult CreateExamSession(Guid id)
        {
            // TODO: Implement method
            // Find the current user, call the service method and when successful redirect to details of ExamSessions CSontroller
            //throw new NotImplementedException();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var session = _examSessionService.CreateExamSession(id, userId);
            return RedirectToAction("Details", "ExamSessions", new { id = session.Id });
        }
    }
    
}
