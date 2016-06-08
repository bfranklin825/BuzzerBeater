using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace BuzzerBeater.DAL
{
    public class BuzzerBeaterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BuzzerBeaterContext>
    {
        protected override void Seed(BuzzerBeaterContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(BuzzerBeaterContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            const string name = "bfranklin825@gmail.com";
            const string password = "dumb11";
            const string roleName = "Admin";

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.CreateAsync(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new Models.ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }

            var teacher = roleManager.FindByName("Teacher");
            if (teacher == null)
            {
                teacher = new IdentityRole("Teacher");
                var teacherResult = roleManager.CreateAsync(role);
            }

            var student = roleManager.FindByName("Student");
            if (student == null)
            {
                student = new IdentityRole("Student");
                var teacherResult = roleManager.CreateAsync(role);
            }
        }
    }
}