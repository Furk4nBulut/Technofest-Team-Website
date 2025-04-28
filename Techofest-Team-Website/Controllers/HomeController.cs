using Microsoft.AspNetCore.Mvc;

namespace Techonefest_Team_Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}