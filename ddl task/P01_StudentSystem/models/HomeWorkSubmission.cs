using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.models
{
    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }
    public class HomeWorkSubmission
    {
        public int HomeWorkId {  get; set; }
          public string Name { get; set; }

        public string Content { get; set; }
        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
