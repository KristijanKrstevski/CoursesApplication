using CoursesApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Interface
{
    public interface ILectureService
    {
        List<Lecture> GetAll();
        Lecture? GetById(Guid id);
        Lecture Insert(Lecture product);
        Lecture Update(Lecture product);
        Lecture DeleteById(Guid id);
    }
}
