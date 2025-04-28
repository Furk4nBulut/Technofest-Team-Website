using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // Kullanıcı tarafında takım üyelerini listele
        public IActionResult Index()
        {
            var teamMembers = _teamService.GetTeamMembers();
            return View(teamMembers);
        }
    }
}