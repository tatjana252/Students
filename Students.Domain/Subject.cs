using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Students.Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int ESPB { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<SubjectItem> Items { get; set; }

        public override string ToString()
        {
            return $"{SubjectId} {Name} {ESPB} {Department.Name}";
        }
    }
}
