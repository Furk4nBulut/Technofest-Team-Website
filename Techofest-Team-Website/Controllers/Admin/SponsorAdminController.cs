using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers.Admin
{
    public class SponsorAdminController : Controller
    {
        private readonly ISponsorService _sponsorService;

        public SponsorAdminController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        // Sponsorları listeleme
        public IActionResult Index()
        {
            var sponsors = _sponsorService.GetSponsors();
            return View(sponsors);
        }

        // Sponsor oluşturma sayfası
        public IActionResult Create()
        {
            return View();
        }

        // Sponsor oluşturma işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _sponsorService.AddSponsor(sponsor);
                return RedirectToAction(nameof(Index));
            }

            // Hata durumunda sponsor verisini geri gönder
            return View(sponsor);
        }

        // Sponsor düzenleme sayfası
        public IActionResult Edit(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // Sponsor düzenleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sponsor sponsor)
        {
            if (id != sponsor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _sponsorService.UpdateSponsor(sponsor);
                return RedirectToAction(nameof(Index));
            }

            return View(sponsor);
        }

        // Sponsor silme sayfası
        public IActionResult Delete(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // Sponsor silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _sponsorService.DeleteSponsor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
