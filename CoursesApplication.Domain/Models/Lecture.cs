using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class Lecture : BaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateOnly Date { get; set; }
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
