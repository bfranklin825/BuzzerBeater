using BuzzerBeater.DAL;
using BuzzerBeater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BuzzerBeater.Controllers
{
    public class ClassController : Controller
    {
        private BuzzerBeaterContext db = new BuzzerBeater.DAL.BuzzerBeaterContext();

        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/Details/5
        public ActionResult Details(Guid id)
        {
            Class selectedclass = db.Classes.Find(id);

            if (selectedclass == null)
            {
                Student s = db.Students.Find(id);
                selectedclass = db.Classes.SingleOrDefault(cla => cla.Students.Select(c => c.StudentId).Contains(s.StudentId));
            }

            return View(selectedclass);
        }

        // GET: Class/Create
        public ActionResult Create(Guid id)
        {
            ViewBag.Teacher_PersonId = id;
            return View(new Class() { Year = Convert.ToInt32(DateTime.Now.Year.ToString()) });
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(Guid id, FormCollection collection)
        {
            ViewBag.Teacher_PersonId = id;
            try
            {
                Teacher classTeacher = db.Teachers.Find(new Guid(collection["Teacher.PersonId"]));
                collection.Remove("Teacher.PersonId");
                Class newClass = new Class() { Teacher = classTeacher, ClassName = collection["ClassName"], Year = Convert.ToInt16(collection["Year"]) };

                if (collection["studentCount"] != null)
                {
                    int studentCount = 0;
                    int.TryParse(collection["StudentCount"], out studentCount);
                    collection.Remove("StudentCount");

                    for (int i = 0; i < studentCount; i++)
                    {
                        newClass.Students.Add(new Student { Password = "student" });
                    }
                    UpdateModel(newClass, collection.ToValueProvider());
                    return View(newClass);
                }
                else
                {
                    //change this to add students login stuff
                    if (ModelState.IsValid)
                    {
                        string[] firstnames = collection["item.FirstName"].Split(char.Parse(","));
                        string[] lastNames = collection["item.LastName"].Split(char.Parse(","));
                        string[] userNames = collection["item.UserName"].Split(char.Parse(","));
                        string[] passwords = collection["item.Password"].Split(char.Parse(","));

                        newClass.Students.Clear();

                        for (int i = 0; i < firstnames.Length; i++)
                        {
                            Student s = new Student { PersonId = Guid.NewGuid() };
                            s.FirstName = firstnames[i];
                            s.LastName = lastNames[i];
                            s.UserName = userNames[i];
                            s.Password = passwords[i];
                            newClass.Students.Add(s);
                        }
                        db.Classes.Add(newClass);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Details", "Teacher", new { id = id });
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(Guid id)
        {
            Class selectedclass = db.Classes.Find(id);
            return View(selectedclass);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class selectedclass = db.Classes.Include(i => i.Students).Where(i => i.ClassId == id).Single();
            var um = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var sim = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

            int studentsToAdd;
            int.TryParse(collection["addStudents"], out studentsToAdd);

            if (studentsToAdd > 0)
            {
                for (int i = 0; i < studentsToAdd; i++)
                {
                    //var regVM = new RegisterViewModel { Email = selectedclass.Teacher.Email + "." + Guid.NewGuid().ToString(), Password = "student" };

                    //var ac = new AccountController(um, sim);
                    //var success = await ac.RegisterLocal(regVM);

                    //if (success != Guid.Empty)
                    //{
                    //    var token = um.GenerateEmailConfirmationToken(success.ToString());
                    //    var confirm = await um.ConfirmEmailAsync(success.ToString(), token);
                    //    if (confirm.Succeeded)
                    //    {
                    //        selectedclass.Students.Add(new Student { PersonId = success, Password = "student" });
                    //    }
                    //    else { return View(selectedclass); }
                    //}
                    //else { return View(selectedclass); }
                }
                db.SaveChanges();
                return View(selectedclass);
            }
            else { collection.Remove("addStudents"); }

            try
            {
                for (int i = 0; i < selectedclass.Students.Count; i++)
                {
                    Student student = selectedclass.Students.Single(t => t.PersonId.ToString() == collection["Students[" + i + "].PersonId"]);
                    student.FirstName = collection["Students[" + i + "].FirstName"];
                    student.LastName = collection["Students[" + i + "].LastName"];
                    student.UserName = collection["Students[" + i + "].UserName"];
                    student.Password = collection["Students[" + i + "].Password"];

                    var user = um.FindById(student.PersonId.ToString());
                    var tokes = um.GeneratePasswordResetToken(student.PersonId.ToString());
                    if (user != null)
                    {
                        um.ResetPassword(student.PersonId.ToString(), tokes, collection["Students[" + i + "].Password"]);
                    }

                    //var user = await um.FindByNameAsync(selectedclass.Teacher.Email + "." + student.UserName);

                    //if (user == null)
                    //{
                    //    var registerVM = new RegisterViewModel
                    //    {
                    //        Email = selectedclass.Teacher.Email + "." + student.UserName,
                    //        Password = student.Password,
                    //        ConfirmPassword = student.Password,
                    //        UserName = student.UserName
                    //    };
                    //    var ac = new AccountController(um, sim);
                    //    var success = await ac.RegisterLocal(registerVM);
                    //}
                }
                db.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View(selectedclass);
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(Guid id)
        {
            Class selectedclass = db.Classes.Find(id);
            ViewBag.Teacher_PersonId = selectedclass.Teacher.PersonId;
            return View(selectedclass);
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            Class selectedclass = db.Classes.Find(id);
            var teacher_personid = selectedclass.Teacher.PersonId;
            ViewBag.Teacher_PersonId = teacher_personid;
            try
            {
                db.Students.RemoveRange(selectedclass.Students);
                db.Classes.Remove(selectedclass);
                db.SaveChanges();
                return RedirectToAction("Details", "Teacher", new { id = teacher_personid });
            }
            catch
            {
                return View(selectedclass);
            }
        }
    }
}
