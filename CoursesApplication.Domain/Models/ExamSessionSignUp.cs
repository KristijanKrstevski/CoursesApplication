using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class ExamSessionSignUp : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public CoursesApplicationUser? User { get; set; }

        public virtual ICollection<CourseInExamSession> CoursesInExamSession { get; set; } = new List<CourseInExamSession>();
    }
}
