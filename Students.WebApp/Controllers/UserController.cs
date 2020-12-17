using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data.UnitOfWork.Users;
using Students.Domain;
using Students.WebApp.Models;

namespace Students.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersUoW unit;

        public UserController(IUsersUoW unit)
        {
            this.unit = unit;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                User user = unit.Users.GetByUsernameAndPassword(new User { Username = model.Username, Password = model.Password });
                HttpContext.Session.SetInt32("userid", user.UserId);
                HttpContext.Session.SetString("username", user.Username);

                HttpContext.Session.Set("user", JsonSerializer.SerializeToUtf8Bytes(user));
                //ViewBag.IsLoggedIn = true;
                return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Wrong credentials!");
                return View();
            }
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [ActionName("Register")]
        public ActionResult Create()
        {
            return View("Register");
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public ActionResult Create(RegisterViewModel model)
        {
            if(unit.Users.Search(u => u.Username == model.Username).Any())
            {
                ModelState.AddModelError(string.Empty, "Username is taken!");
                return View();
            }
            unit.Users.Add(new Domain.User { FirstName = model.FirstName, LastName = model.Lastname, Username = model.Username, Password = model.Password });
            unit.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
