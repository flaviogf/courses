using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Students;

namespace School.Infra.Students
{
    public class MD5Hash : IHash
    {
        public Task<string> Make(string value)
        {
            var md5 = MD5.Create();

            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            var sb = new StringBuilder();

            foreach (var it in bytes)
            {
                sb.Append(it.ToString("x2"));
            }

            var result = sb.ToString();

            return Task.FromResult(result);
        }

        public async Task<bool> Compare(string value, string hash)
        {
            var result = (await Make(value)) == hash;

            return result;
        }
    }
}
