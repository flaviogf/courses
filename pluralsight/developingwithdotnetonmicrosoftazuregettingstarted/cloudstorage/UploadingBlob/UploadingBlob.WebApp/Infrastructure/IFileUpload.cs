using System.IO;
using System.Threading.Tasks;

namespace UploadingBlob.WebApp.Infrastructure
{
    public interface IFileUpload
    {
        Task<string> Save(Stream stream);

        Task<string> Url(string id);
    }
}
