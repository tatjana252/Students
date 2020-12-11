using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Students.Data.UnitOfWork;
using Students.Domain;
using Students.WebApp.Models;

namespace Students.WebApp.Controllers
{
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

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
