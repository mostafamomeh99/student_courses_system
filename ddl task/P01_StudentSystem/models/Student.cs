using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? PhoneNumber { get; set; }

        public DateOnly RegestrionON { get; set; }

        List<Course> Courses { get; set; }  = new List<Course>();
        public ICollection<StudentCourse> StudentCourses { get; set; }=new List<StudentCourse>();
        public ICollection<HomeWorkSubmission> HomeWorkSubmissions { get; set; } = new List<HomeWorkSubmission>();
        
    }
}
