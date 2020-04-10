using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;

namespace UploadingBlob.WebApp.Infrastructure
{
    public class BlobStorage : IFileUpload
    {
        private readonly StorageSharedKeyCredential _key;

        private readonly BlobContainerClient _container;

        public BlobStorage(IConfiguration configuration)
        {
            _key = new StorageSharedKeyCredential(configuration["StorageAccount:Name"], configuration["StorageAccount:Key"]);

            var service = new BlobServiceClient(new Uri(configuration["StorageAccount:Url"]), _key);

            _container = service.GetBlobContainerClient("images");
        }

        public async Task<string> Save(Stream stream)
        {
            var name = Guid.NewGuid().ToString();

            var blob = _container.GetBlobClient(name);

            await blob.UploadAsync(stream);

            return name;
        }

        public async Task<string> Url(string id)
        {
            var blob = _container.GetBlobClient(id);

            var sas = new BlobSasBuilder
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow.AddMinutes(-15),
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(15)
            };

            sas.SetPermissions(BlobContainerSasPermissions.Read);

            return $"{blob.Uri}?{sas.ToSasQueryParameters(_key)}";
        }
    }
}
