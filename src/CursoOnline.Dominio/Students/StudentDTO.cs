using OnlineCourse.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Domain.Students
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string TargetAudience { get; set; }
        public string Email { get; set; }
        public int Id;
    }
}
