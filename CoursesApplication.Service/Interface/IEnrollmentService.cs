using CoursesApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Interface
{
    public interface IEnrollmentService
    {
        Enrollment EnrollStudentOnCourse(Guid studentId, Guid courseId, string userId, bool reEnroll);
        List<Enrollment> GetAllByUser(string userId);
        Enrollment? GetById(Guid id);
        Enrollment DeleteById(Guid id);

       
    }
}
