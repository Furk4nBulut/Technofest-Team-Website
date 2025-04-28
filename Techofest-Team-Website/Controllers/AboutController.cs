using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;
using System.Threading.Tasks;

namespace Techonefest_Team_Website.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        // Hakkımızda sayfasını listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Hakkımızda verisini servisten alıyoruz
            var about = _aboutService.GetAboutInfo();
            return View(about);
        }

        // Hakkımızda sayfasını güncelleme işlemi
        [HttpPost]
        public IActionResult Update(About about)
        {
            if (ModelState.IsValid)
            {
                // Hakkımızda verisini güncelliyoruz
                _aboutService.UpdateAbout(about);
                return RedirectToAction("Index");
            }

            return View("Index", about);
        }
    }
}