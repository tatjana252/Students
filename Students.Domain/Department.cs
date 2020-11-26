using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Students.Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(3)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{DepartmentId}: {Name}";
        }
    }
}
