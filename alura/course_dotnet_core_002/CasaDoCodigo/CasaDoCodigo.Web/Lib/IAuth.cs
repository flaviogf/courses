using CasaDoCodigo.Web.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Lib
{
    public interface IAuth
    {
        Task<User> Login(User user);

        Task<User> Logout();

        Task<User> User();
    }
}
