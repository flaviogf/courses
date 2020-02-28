using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Section3.UsingTheCallerMemberName.Controllers
{
    public class Controller
    {
        public string View([CallerMemberName]string view = null)
        {
            var name = Regex.Match(GetType().Name, @"^(?<Name>\w+)Controller$").Groups["Name"].Value;

            var path = Path.Join(Directory.GetCurrentDirectory(), "Views", name, $"{view}.cshtml");

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}