using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class CourseInExamSession : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid ExamSessionId { get; set; }
        public ExamSessionSignUp ExamSession { get; set; }
    }
}
