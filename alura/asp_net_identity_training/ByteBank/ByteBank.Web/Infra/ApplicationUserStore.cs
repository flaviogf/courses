using ByteBank.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ByteBank.Web.Infra
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ByteBankDbContext context) : base(context)
        {
        }
    }
}