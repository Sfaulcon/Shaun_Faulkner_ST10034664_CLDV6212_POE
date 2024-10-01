using Azure.Storage.Queues;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public class QueueStorageService : IQueueStorageService
    {
        private readonly QueueClient _queueClient;

        public QueueStorageService(QueueServiceClient queueServiceClient)
        {
            _queueClient = queueServiceClient.GetQueueClient("productqueue");
        }

        public async Task SendMessageAsync(string message)
        {
            await _queueClient.SendMessageAsync(message);
        }
    }
}
