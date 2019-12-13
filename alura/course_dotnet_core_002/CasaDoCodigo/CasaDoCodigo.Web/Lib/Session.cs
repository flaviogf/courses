using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Lib
{
    public class Session : IAuth
    {
        private readonly ApplicationContext _context;

        private readonly ISession _session;

        public Session(ApplicationContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _session = accessor.HttpContext.Session;
        }

        public async Task<User> Login(User user)
        {
            _session.SetInt32("@user", user.Id);

            return user;
        }

        public async Task<User> Logout()
        {
            var id = _session.GetInt32("@user");

            var user = await (from currrent in _context.Users
                              .Include(it => it.Address)
                              where currrent.Id == id
                              select currrent).FirstAsync();

            _session.Remove("@user");

            return user;
        }

        public async Task<User> User()
        {
            var id = _session.GetInt32("@user");

            var user = await (from currrent in _context.Users
                              .Include(it => it.Address)
                              where currrent.Id == id
                              select currrent).FirstAsync();

            return user;
        }
    }
}
