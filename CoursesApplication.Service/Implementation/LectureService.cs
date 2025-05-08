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
    public class LectureService : ILectureService
    {
        private readonly IRepository<Lecture> _lectureRepository;

        public LectureService(IRepository<Lecture> lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public Lecture DeleteById(Guid id)
        {
            var lecture = GetById(id);

            if (lecture == null)
            {
                throw new ArgumentNullException("course");
            }

            return _lectureRepository.Delete(lecture);
        }

        public List<Lecture> GetAll()
        {
            return _lectureRepository.GetAll(selector: x => x).ToList();
        }

        public Lecture? GetById(Guid id)
        {
            return _lectureRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id
                );
        }

        public Lecture Insert(Lecture lecture)
        {
            return _lectureRepository.Insert(lecture);
        }

        public Lecture Update(Lecture lecture)
        {
            return _lectureRepository.Update(lecture);
        }
    }
}
