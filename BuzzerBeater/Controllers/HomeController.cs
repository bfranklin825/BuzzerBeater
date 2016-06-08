using BuzzerBeater.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BuzzerBeater.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult EmailVerification()
        {
            return View();
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            //var ac = new AccountController(Request.GetOwinContext().GetUserManager<ApplicationUserManager>());
            //TextResult result = await ac.ConfirmEmail(userId, code);

            var UserManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                var email = UserManager.GetEmail(userId);

                //create new teacher here
                //var addTeacher = new Teacher { PersonId = new Guid(userId), Email = UserManager.GetEmail(userId) };
                //db.Teachers.Add(addTeacher);
                //var newteach = db.Teachers.Find(addTeacher.PersonId);
                //db.SaveChanges();

                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }
}
