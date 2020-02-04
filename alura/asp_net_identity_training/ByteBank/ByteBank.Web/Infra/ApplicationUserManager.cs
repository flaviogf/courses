using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;

namespace ByteBank.Web.Infra
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                RequireUniqueEmail = true
            };
        }
    }
}