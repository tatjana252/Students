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
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork uow;

        public SubjectController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // GET: SubjectController
        public ActionResult Index()
        {
            return View(uow.Subject.GetAll());
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            foreach(Department d in uow.Department.GetAll())
            {
                departments.Add(new SelectListItem { Value = d.DepartmentId.ToString(), Text = d.Name }); ;
            }
            ViewBag.Departments = departments;
            ViewData["Departments"] = departments;


            CreateSubjectViewModel model = new CreateSubjectViewModel { Departments = departments };

            return View(model);
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]CreateSubjectViewModel subject)
        {
            try
            {
                Subject s = new Subject
                {
                    DepartmentId = subject.DepartmentId,
                    ESPB = subject.ESPB,
                    Name = subject.Name
                };
                uow.Subject.Add(s);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
