using Techonefest_Team_Website.Data;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Techonefest_Team_Website.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TeamMember> GetTeamMembers()
        {
            return _context.TeamMembers.ToList();
        }

        public TeamMember GetTeamMemberById(int id)
        {
            return _context.TeamMembers.FirstOrDefault(m => m.Id == id);
        }

        public void AddTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
        }

        public void UpdateTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Update(teamMember);
            _context.SaveChanges();
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = _context.TeamMembers.FirstOrDefault(m => m.Id == id);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                _context.SaveChanges();
            }
        }
    }
}