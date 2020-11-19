using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain
{
    public class Enrollment
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
