using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ISponsorService _sponsorService;

        public HomeController(IAboutService aboutService, ISponsorService sponsorService)
        {
            _aboutService = aboutService;
            _sponsorService = sponsorService;
        }

        // Ana sayfa işlemi
        public IActionResult Index()
        {
            // Hakkımızda bilgisini servisten alıyoruz
            var about = _aboutService.GetAboutInfo();
            
            // Sponsor verilerini servisten alıyoruz
            var sponsors = _sponsorService.GetSponsors();

            // Her iki model verisini aynı anda View'e gönderiyoruz
            ViewBag.AboutContent = about;
            ViewBag.Sponsors = sponsors;

            return View();
        }
    }
}