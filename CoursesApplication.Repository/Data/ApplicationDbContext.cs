using CoursesApplication.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoursesApplication.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<CoursesApplicationUser> CoursesApplicationUsers { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        //db
        public virtual DbSet<ExamSessionSignUp> ExamSessionSignUp { get; set; }
        public virtual DbSet<CourseInExamSession> CourseInExamSession { get; set; }

    }
}
