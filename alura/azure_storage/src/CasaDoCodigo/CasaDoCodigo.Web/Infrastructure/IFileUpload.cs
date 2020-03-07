using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Infrastructure
{
    public interface IFileUpload
    {
        Task<string> Upload(IFormFile file);

        string UrlFor(string path);
    }
}
