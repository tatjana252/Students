using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{DepartmentId}: {Name}";
        }
    }
}
