using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers.Admin
{
    public class ServiceAdminController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceAdminController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // Tüm servisleri listele
        public IActionResult Index()
        {
            var services = _serviceService.GetServices();
            return View(services);
        }

        // Yeni servis ekleme sayfası
        public IActionResult Create()
        {
            return View();
        }

        // Yeni servis ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceService.AddService(service);
                return RedirectToAction(nameof(Index));
            }

            return View(service);
        }

        // Servis düzenleme sayfası
        public IActionResult Edit(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // Servis düzenleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _serviceService.UpdateService(service);
                return RedirectToAction(nameof(Index));
            }

            return View(service);
        }

        // Servis silme sayfası
        public IActionResult Delete(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // Servis silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _serviceService.DeleteService(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
