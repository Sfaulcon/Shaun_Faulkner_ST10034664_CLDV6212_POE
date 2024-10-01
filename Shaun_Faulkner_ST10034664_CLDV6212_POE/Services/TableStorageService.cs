using Azure.Data.Tables;
using Shaun_Faulkner_ST10034664_CLDV6212_POE.Models;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public class TableStorageService : ITableStorageService
    {
        private readonly TableClient _tableClient;

        public TableStorageService(TableServiceClient tableServiceClient)
        {
            _tableClient = tableServiceClient.GetTableClient("ProductsTable");
        }

        public async Task AddProductAsync(ProductViewModel model, string imageUri)
        {
            var productEntity = new TableEntity("ProductPartition", Guid.NewGuid().ToString())
            {
                { "Name", model.Name },
                { "Price", model.Price },
                { "Quantity", model.Quantity },
                { "ImageUri", imageUri }
            };

            await _tableClient.AddEntityAsync(productEntity);
        }
    }
}
