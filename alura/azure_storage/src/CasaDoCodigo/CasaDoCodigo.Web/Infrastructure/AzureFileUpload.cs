using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Infrastructure
{
    public class AzureFileUpload : IFileUpload
    {
        private readonly IConfiguration _configuration;

        public AzureFileUpload(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var connectionString = _configuration["StorageAccount:ConnectionString"];

            var containerName = _configuration["StorageContainer:BookCover:Name"];

            var blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var blobName = $"{Guid.NewGuid()}-{file.FileName}";

            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = file.OpenReadStream();

            await blobClient.UploadAsync(stream);

            return blobName;
        }

        public string UrlFor(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;

            var url = _configuration["StorageContainer:BookCover:Url"];

            return $"{url}/{path}";
        }
    }
}
