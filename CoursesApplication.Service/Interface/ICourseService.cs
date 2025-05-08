using CoursesApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Interface
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course? GetById(Guid id);
        Course Insert(Course product);
        Course Update(Course product);
        Course DeleteById(Guid id);
    }
}
