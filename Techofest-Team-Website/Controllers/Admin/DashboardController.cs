using Microsoft.AspNetCore.Mvc;

namespace Techonefest_Team_Website.Controllers.Admin
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}