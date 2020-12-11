using Microsoft.AspNetCore.Mvc.Rendering;
using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.WebApp.Models
{
    public class CreateStudentViewModel
    {
        public Student Student { get; set; }

        public List<SelectListItem> Subjects { get; set; }

    }
}
