using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CasaDoCodigo.Web.Lib
{
    public class Session : IAuth
    {
        private readonly ISession _session;

        public Session(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public async Task<User> Login(User user)
        {
            var serializer = new XmlSerializer(typeof(User));

            var writer = new StringWriter();

            serializer.Serialize(writer, user);

            _session.SetString("@user", writer.ToString());

            return user;
        }

        public async Task<User> Logout()
        {
            var serializer = new XmlSerializer(typeof(User));

            var reader = new StringReader(_session.GetString("@user"));

            var user = (User)serializer.Deserialize(reader);

            _session.Remove("@user");

            return user;
        }

        public async Task<User> User()
        {
            var serializer = new XmlSerializer(typeof(User));

            var reader = new StringReader(_session.GetString("@user"));

            var user = (User)serializer.Deserialize(reader);

            return user;
        }
    }
}
