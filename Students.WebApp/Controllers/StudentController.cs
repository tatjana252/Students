using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Students.Data.UnitOfWork;
using Students.Domain;
using Students.WebApp.Filters;
using Students.WebApp.Models;

namespace Students.WebApp.Controllers
{
    [LoggedInUser]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork uow;

        public StudentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentController/Create
        
        public ActionResult Create()
        {
            List<Subject> list = uow.Subject.GetAll();
            List<SelectListItem> selectList = list.Select(s => new SelectListItem { Text = s.Name, Value = s.SId.ToString() }).ToList();


            CreateStudentViewModel model = new CreateStudentViewModel {
                Subjects = selectList
            };
            return View(model);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStudentViewModel viewmodel)
        {
            try
            {
                uow.Student.Add(viewmodel.Student);
                uow.Commit();
                return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public ActionResult AddSubject(EnrollmentViewModel request)
        {
            Subject s = uow.Subject.FindById(request.SubjectId);
            EnrollmentViewModel model = new EnrollmentViewModel {
                Num = request.Num,
                SubjectId = request.SubjectId, 
                Name = s.Name,
                Department = s.Department.Name,
                ESPB = s.ESPB
            };
            return PartialView("EnrollmentPartial", model);
        }


    }
}
