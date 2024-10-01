namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
