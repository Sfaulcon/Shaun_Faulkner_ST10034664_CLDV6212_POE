using Azure.Storage.Files.Shares;
using Shaun_Faulkner_ST10034664_CLDV6212_POE.Models;
using System.Text;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public class FileShareService : IFileShareService
    {
        private readonly ShareClient _shareClient;

        public FileShareService(ShareServiceClient shareServiceClient)
        {
            _shareClient = shareServiceClient.GetShareClient("productfiles");
        }

        public async Task SaveProductDetailsToFileAsync(ProductViewModel model)
        {
            var directoryClient = _shareClient.GetRootDirectoryClient();
            var fileClient = directoryClient.GetFileClient($"{model.Name}_details.txt");

            var content = $"Product: {model.Name}\nPrice: {model.Price}\nQuantity {model.Quantity}";
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadAsync(stream);
            }
        }
    }
}
