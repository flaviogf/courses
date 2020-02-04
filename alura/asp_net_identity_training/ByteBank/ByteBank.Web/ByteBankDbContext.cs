using ByteBank.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ByteBank.Web
{
    public class ByteBankDbContext : IdentityDbContext<ApplicationUser>
    {
        public ByteBankDbContext() : base("ByteBankDbContext")
        {
        }
    }
}