using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;

        // HomeController'a IAboutService bağımlılığı ekleniyor
        public HomeController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        // Ana sayfa işlemi
        public IActionResult Index()
        {
            // Hakkımızda bilgisini servisten alıyoruz
            var about = _aboutService.GetAboutInfo();

            // View'e model olarak Hakkımızda bilgilerini gönderiyoruz
            return View(about);
        }
    }
}