using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.Models
{
    public class CoursesApplicationUser : IdentityUser
    {

        public DateOnly DateOfBirth { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
