using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Implementation
{
    public class EnrollementService : IEnrollmentService
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IRepository<Enrollment> _enrollementRepository;
        private readonly IRepository<ExamSessionSignUp> _examSessionRepository;

        public EnrollementService(IStudentService studentService, ICourseService courseService, IRepository<Enrollment> enrollementRepository)
        {
            _studentService = studentService;
            _courseService = courseService;
            _enrollementRepository = enrollementRepository;
        }

    
        public Enrollment DeleteById(Guid id)
        {
            // TODO: Implement method
            // throw new NotImplementedException();

            var enrollment = _enrollementRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id
            );

            return _enrollementRepository.Delete(enrollment);
        }

        public Enrollment EnrollStudentOnCourse(Guid studentId, Guid courseId, string userId, bool reEnroll)
        {
            var student = _studentService.GetById(studentId);
            var course = _courseService.GetById(courseId);

            if(student == null || course == null) 
            {
                throw new ArgumentNullException("student");
            }

            var enrollment = new Enrollment()
            {
                StudentId = studentId,
                Student = student,
                CourseId = courseId,
                Course = course,
                UserId = userId,
                DateEnrolled = DateTime.Now,
                ReEnrolled = reEnroll
            };

            return _enrollementRepository.Insert(enrollment);
        }

        public List<Enrollment> GetAllByUser(string userId)
        {
            return _enrollementRepository.GetAll(
                selector: x => x,
                predicate: x => x.UserId == userId,
                include: x => x.Include(y => y.Course)
                                .Include(y => y.User)
                                .Include(y => y.Student)).ToList();
        }

        public Enrollment? GetById(Guid id)
        {
            return _enrollementRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.Course)
                                .Include(y => y.User)
                                .Include(y => y.Student));
        }

    }
}
