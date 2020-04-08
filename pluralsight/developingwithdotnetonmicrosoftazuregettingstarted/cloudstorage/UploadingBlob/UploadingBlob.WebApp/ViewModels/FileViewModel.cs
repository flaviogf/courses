using Microsoft.AspNetCore.Http;

namespace UploadingBlob.WebApp.ViewModels
{
    public class FileViewModel
    {
        public IFormFile File { get; set; }

        public string Url { get; set; }
    }
}
