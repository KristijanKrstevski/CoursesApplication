using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student DeleteById(Guid id)
        {
            var student = GetById(id);

            if (student == null)
            {
                throw new ArgumentNullException("course");
            }

            return _studentRepository.Delete(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll(selector: x => x).ToList();
        }

        public Student? GetById(Guid id)
        {
            return _studentRepository.Get(
                selector: x => x, 
                predicate: x => x.Id == id
                );
        }

        public Student Insert(Student student)
        {
            return _studentRepository.Insert(student);
        }

        public Student Update(Student student)
        {
            return _studentRepository.Update(student);
        }
    }
}
