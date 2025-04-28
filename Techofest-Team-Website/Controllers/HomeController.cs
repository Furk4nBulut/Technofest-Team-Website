using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ISponsorService _sponsorService;
        private readonly IServiceService _serviceService;

        public HomeController(IAboutService aboutService, ISponsorService sponsorService, IServiceService serviceService)
        {
            _aboutService = aboutService;
            _sponsorService = sponsorService;
            _serviceService = serviceService;
        }

        // Ana sayfa işlemi
        public IActionResult Index()
        {
            // Hakkımızda bilgisini servisten alıyoruz
            var about = _aboutService.GetAboutInfo();
            
            // Sponsor verilerini servisten alıyoruz
            var sponsors = _sponsorService.GetSponsors();
            
            // Hizmet verilerini servisten alıyoruz
            var services = _serviceService.GetServices();

            // Null kontrolü ekliyoruz
            ViewBag.AboutContent = about ?? new About();  // Eğer null ise boş bir About objesi
            ViewBag.Sponsors = sponsors ?? new List<Sponsor>();  // Eğer null ise boş bir liste
            ViewBag.Services = services ?? new List<Service>();  // Eğer null ise boş bir liste

            return View();
        }
    }
}