using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace ByteBank.Web
{
    public static class AdminConfig
    {
        public static void RegisterAdmin()
        {
            using (var context = new ByteBankDbContext())
            using (var userStore = new UserStore<ApplicationUser>(context))
            using (var userManager = new UserManager<ApplicationUser>(userStore))
            using (var roleStore = new RoleStore<IdentityRole>(context))
            using (var roleManager = new RoleManager<IdentityRole>(roleStore))
            {
                var password = ConfigurationManager.AppSettings["Admin:Password"];

                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@bytebank.com",
                    EmailConfirmed = true
                };

                userManager.Create(adminUser, password);

                var adminRole = new IdentityRole("admin");

                roleManager.Create(adminRole);

                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }
        }
    }
}