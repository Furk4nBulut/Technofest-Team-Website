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
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(email, password);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password.");
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