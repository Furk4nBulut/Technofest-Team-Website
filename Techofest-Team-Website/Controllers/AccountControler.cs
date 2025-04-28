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
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Login işlemi
                var result = await _authService.LoginAsync(email, password);
        
                if (result)
                {
                    // Eğer ReturnUrl varsa, ona yönlendir
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    // Aksi takdirde ana sayfaya yönlendir
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Hata mesajı ekleyin
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            // Eğer model geçerli değilse veya login başarısızsa, tekrar login sayfasını döndür
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