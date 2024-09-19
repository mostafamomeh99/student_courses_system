using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.models
{

    
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        List<Student> Students { get; set; }= new List<Student>();
        public ICollection<StudentCourse> StudentCourses { get; set; }= new List<StudentCourse>();

        public ICollection<HomeWorkSubmission> HomeWorkSubmissions { get; set; } = new List<HomeWorkSubmission>();
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

    }
}
