using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.DTO
{
    public class ExamSessionDetailsDTO
    {
        public Guid SessionId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> CourseNames { get; set; } = new List<string>();
        public int TotalCourses => CourseNames.Count;
    }
}
