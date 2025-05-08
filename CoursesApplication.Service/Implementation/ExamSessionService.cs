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
    public class ExamSessionService : IExamSessionService
    {
        private readonly IRepository<ExamSessionSignUp> _examSessionRepository;

        public ExamSessionService(IRepository<ExamSessionSignUp> examSessionRepository)
        {
            _examSessionRepository = examSessionRepository;
        }

        public ExamSessionSignUp GetExamSessionDetails(Guid id)
        {
            //TODO
            return _examSessionRepository.Get(
                selector: x => x,
                predicate: x => x.Id == id,
                include: x => x
                    .Include(e => e.User)
                    .Include(e => e.CoursesInExamSession)
                        .ThenInclude(c => c.Course)
            );
        }

        public ExamSessionSignUp CreateExamSession(Guid enrollmentId, string userId)
        {
            //TODO


            var signUp = new ExamSessionSignUp
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(userId),
                DateCreated = DateTime.UtcNow
            };

            return _examSessionRepository.Insert(signUp);
        }
    }
}
