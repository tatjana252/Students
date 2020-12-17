﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.WebApp.Filters
{
    public class LoggedInUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Filters.OfType<NotLoggedIn>().Any())
            {
                return;
            }

           if(context.HttpContext.Session.GetInt32("userid") == null)
            {
                context.HttpContext.Response.Redirect("/user/index");
                return;
            }
            else
            {
                Controller controller = (Controller)context.Controller;
                controller.ViewBag.IsLoggedIn = true;
            }
        }
    }
}
