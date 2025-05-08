using CoursesApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Interface
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student? GetById(Guid id);
        Student Insert(Student product);
        Student Update(Student product);
        Student DeleteById(Guid id);
    }
}
