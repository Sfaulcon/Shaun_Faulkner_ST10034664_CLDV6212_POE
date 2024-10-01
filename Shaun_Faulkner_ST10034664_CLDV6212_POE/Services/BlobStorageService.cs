using Azure.Storage.Blobs;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("File is empty");
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient("products");
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(file.Name);

            using (var stream = file.OpenReadStream())
            {
                {
                    await blobClient.UploadAsync(stream, true);
                }

                return blobClient.Uri.ToString();
            }
        }
    }
}
