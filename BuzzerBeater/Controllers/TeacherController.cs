using BuzzerBeater.DAL;
using BuzzerBeater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuzzerBeater.Controllers
{
    public class TeacherController : Controller
    {
        private BuzzerBeaterContext db = new BuzzerBeaterContext();

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/Details/5
        public ActionResult Details(Guid id)
        {
            var vm = new TeacherMainModel();
            vm.Teacher = db.Teachers.Find(id);
            vm.Classes = db.Classes.Where(c => c.Teacher.PersonId == vm.Teacher.PersonId).OrderByDescending(o => o.Year);
            var tests = db.Tests.Where(t => t.Owner.PersonId == vm.Teacher.PersonId || t.DefaultTest == true);
            foreach (var t in tests)
            {
                t.NumberOfQuestions = db.Questions.Where(q => q.Test.TestId == t.TestId).Count();
                t.Owner = vm.Teacher;
            }
            vm.Tests = tests;

            return View(vm);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(Guid id)
        {
            var myTeacherAccount = db.Teachers.Find(id);
            return View(myTeacherAccount);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Teacher model = db.Teachers.Find(id);
                UpdateModel(model, collection.ToValueProvider());
                db.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
