public interface ITeamService
{
    IEnumerable<TeamMember> GetAllTeamMembers();
    void AddTeamMember(TeamMember member);
}