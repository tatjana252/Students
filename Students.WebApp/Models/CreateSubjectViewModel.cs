using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.WebApp.Models
{
    public class CreateSubjectViewModel
    {
        public List<SelectListItem> Departments { get; set; }
        public string Name { get; set; }
        public int ESPB { get; set; }
        public int DepartmentId { get; set; }

    }
}
