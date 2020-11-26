using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data.UnitOfWork;
using Students.Domain;

namespace Students.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            List<Department> model = unitOfWork.Department.GetAll();
            return View("Index", model);
        }

        public ActionResult Details([FromRoute(Name ="id")]int idDepartment)
        {
            Department model = unitOfWork.Department.FindById(idDepartment);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateDepartment");
        }

        [HttpPost]
        [ActionName("CreateDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDepartment");
            }
            unitOfWork.Department.Add(department);
            unitOfWork.Commit();
            return Index();
        }
    }
}
