using Microsoft.AspNetCore.Mvc;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Controllers.Admin
{
    public class TeamAdminController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamAdminController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // Takım üyelerini listele
        public IActionResult Index()
        {
            var teamMembers = _teamService.GetTeamMembers();
            return View(teamMembers);
        }

        // Yeni takım üyesi ekle formu
        public IActionResult Create()
        {
            return View();
        }

        // Yeni takım üyesi ekle işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                _teamService.AddTeamMember(teamMember);
                return RedirectToAction(nameof(Index));
            }
            return View(teamMember);
        }


        // Takım üyesi düzenleme formu
        public IActionResult Edit(int id)
        {
            var teamMember = _teamService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // Takım üyesi düzenleme işlemi
        [HttpPost]
        public IActionResult Edit(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _teamService.UpdateTeamMember(teamMember);
                return RedirectToAction(nameof(Index));
            }

            return View(teamMember);
        }

        // Takım üyesi silme işlemi için onay sayfası
        public IActionResult Delete(int id)
        {
            var teamMember = _teamService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // Silme işlemi
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _teamService.DeleteTeamMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
