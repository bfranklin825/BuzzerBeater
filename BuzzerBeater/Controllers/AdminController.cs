using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuzzerBeater.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(Guid id)
        {
            //var vm = new TeacherMainModel();
            //vm.Teacher = db.Teachers.Find(id);
            //vm.Classes = db.Classes.Where(c => c.Teacher.PersonId == vm.Teacher.PersonId).OrderByDescending(o => o.Year);
            //var tests = db.Tests.Where(t => t.Owner.PersonId == vm.Teacher.PersonId || t.DefaultTest == true);
            //foreach (var t in tests)
            //{
            //    t.NumberOfQuestions = db.Questions.Where(q => q.Test.TestId == t.TestId).Count();
            //    t.Owner = vm.Teacher;
            //}
            //vm.Tests = tests;

            return View();
        }
    }
}