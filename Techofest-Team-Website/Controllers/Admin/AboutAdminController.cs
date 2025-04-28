using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class AboutAdminController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutAdminController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAboutInfo();
            return View(about);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var about = _aboutService.GetAboutInfo();
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                _aboutService.UpdateAbout(about);
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }
    }
}