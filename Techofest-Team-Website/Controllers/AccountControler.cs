using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(email, password);

                if (result)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    // BAŞARILI login sonrası doğrudan Dashboard/Index'e yönlendiriyoruz.
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}