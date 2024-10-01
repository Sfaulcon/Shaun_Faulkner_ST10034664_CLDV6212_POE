namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public interface IQueueStorageService
    {
        Task SendMessageAsync(string message);
    }
}
