using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class Enrollment : BaseEntity
    {
        public Guid Id { get; set; }
        public required DateTime DateEnrolled { get; set; }
        public bool ReEnrolled { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public CoursesApplicationUser User { get; set; }
    }
}
