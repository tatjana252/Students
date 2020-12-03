using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Students.Domain
{
    public class Subject
    {
        [Column("SubjectId")]
        public int SId { get; set; }
        public string Name { get; set; }
        public int ESPB { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Enrollment> Students { get; set; }

        public List<SubjectItem> Items { get; set; }

        public override string ToString()
        {
            return $"{SId} {Name} {ESPB} {Department.Name}";
        }
    }
}
