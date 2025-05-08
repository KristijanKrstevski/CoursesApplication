using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class Course : BaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Semester { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
