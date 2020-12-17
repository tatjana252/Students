using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.WebApp.Models
{
    public class EnrollmentViewModel
    {
        public int Num { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int ESPB { get; set; }
    }
}
