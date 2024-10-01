using Shaun_Faulkner_ST10034664_CLDV6212_POE.Models;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Services
{
    public interface IFileShareService
    {
        Task SaveProductDetailsToFileAsync(ProductViewModel model);
    }
}
