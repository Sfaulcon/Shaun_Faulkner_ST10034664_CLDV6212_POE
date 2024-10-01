using Microsoft.AspNetCore.Mvc;
using Shaun_Faulkner_ST10034664_CLDV6212_POE.Models;
using Shaun_Faulkner_ST10034664_CLDV6212_POE.Services;
using System.Diagnostics;

namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlobStorageService _blobService;
        private readonly ITableStorageService _tableService;
        private readonly IQueueStorageService _queueService;
        private readonly IFileShareService _fileShareService;

        public HomeController(ILogger<HomeController> logger, IBlobStorageService blobService, ITableStorageService tableService, IQueueStorageService queueService, IFileShareService fileShareService)
        {
            _logger = logger;
            _blobService = blobService;
            _tableService = tableService;
            _queueService = queueService;
            _fileShareService = fileShareService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imageUri = await _blobService.UploadFileAsync(model.ProductImage);

                await _tableService.AddProductAsync(model, imageUri);

                await _fileShareService.SaveProductDetailsToFileAsync(model);

                await _queueService.SendMessageAsync($"Product '{model.Name}' uploaded.");

                return RedirectToAction("Index");
            }
            return View("Index", model);
        }
    }
}
