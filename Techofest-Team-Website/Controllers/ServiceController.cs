using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Services.Interfaces;
using Techonefest_Team_Website.Models;

namespace Techonefest_Team_Website.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // Hizmetler sayfası
        public IActionResult Index()
        {
            var services = _serviceService.GetServices();  // Hizmetleri alıyoruz
            return View(services);  // View'e gönderiyoruz
        }
    }
}
