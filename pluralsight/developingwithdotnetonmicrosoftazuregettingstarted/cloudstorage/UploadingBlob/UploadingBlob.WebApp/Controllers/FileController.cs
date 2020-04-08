using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UploadingBlob.WebApp.Infrastructure;
using UploadingBlob.WebApp.ViewModels;

namespace UploadingBlob.WebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileUpload _fileUpload;

        private readonly ILogger<FileController> _logger;

        public FileController(IFileUpload fileUpload, ILogger<FileController> logger)
        {
            _fileUpload = fileUpload;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store([FromForm] FileViewModel viewModel)
        {
            using var file = viewModel.File.OpenReadStream();

            var name = await _fileUpload.Save(file);

            _logger.LogInformation($"File {name} have been uploaded");

            return RedirectToAction(nameof(Show), new { id = name });
        }

        [HttpGet]
        public async Task<IActionResult> Show(string id)
        {
            var url = await _fileUpload.Url(id);

            var viewModel = new FileViewModel
            {
                Url = url
            };

            return View(viewModel);
        }
    }
}
