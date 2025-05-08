using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class Student : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        
        [Required]
        public required string Surname { get; set; }
        
        [Required]
        public DateOnly DateOfBirth { get; set; }
        
        [Required]
        public required string Index {  get; set; }
        public int EnrollmentYear { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
