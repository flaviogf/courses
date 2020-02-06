using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace ByteBank.Web.Infra
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IDataProtectionProvider provider) : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                RequireUniqueEmail = true
            };

            EmailService = new EmailIdentityMessageService();

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("ByteBank"));
        }
    }
}