using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data.UnitOfWork;
using Students.Domain;
using Students.WebApp.Filters;

namespace Students.WebApp.Controllers
{
    [LoggedInUser]
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
            int? userid = HttpContext.Session.GetInt32("userid");
            if (userid != null)
            {
                ViewBag.IsLoggedIn = true;
                ViewBag.Username = HttpContext.Session.GetString("username");
                byte[] userBy = HttpContext.Session.Get("user");
                User user = JsonSerializer.Deserialize<User>(userBy);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
            return View("Index", model);
        }

        //localhost/Department/5
        [NotLoggedIn]
        public ActionResult Details([FromRoute(Name = "id")] int idDepartment)
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
        public ActionResult Create([FromForm] Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDepartment");
            }

            bool exists = unitOfWork.Department.Search(d => d.Name == department.Name).Any();
            if (exists)
            {
                ModelState.AddModelError("DepartmentName", "Department name already exists!");
                return View("CreateDepartment");
            }

            unitOfWork.Department.Add(department);
            unitOfWork.Commit();
            return Index();
        }
    }
}
