using Techonefest_Team_Website.Models;
using System.Collections.Generic;

namespace Techonefest_Team_Website.Services.Interfaces
{
    public interface ITeamService
    {
        List<TeamMember> GetTeamMembers();
        TeamMember GetTeamMemberById(int id);
        void AddTeamMember(TeamMember teamMember);
        void UpdateTeamMember(TeamMember teamMember);
        void DeleteTeamMember(int id);
    }
}