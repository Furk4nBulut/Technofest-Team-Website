

using Techonefest_Team_Website.Data;

public class TeamService : ITeamService
{
    private readonly ApplicationDbContext _context;

    public TeamService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TeamMember> GetAllTeamMembers()
    {
        return _context.TeamMembers.ToList();
    }

    public void AddTeamMember(TeamMember member)
    {
        _context.TeamMembers.Add(member);
        _context.SaveChanges();
    }
}