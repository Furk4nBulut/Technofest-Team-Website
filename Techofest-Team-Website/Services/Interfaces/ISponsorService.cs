using System.Collections.Generic;
using Techonefest_Team_Website.Models;

namespace Techonefest_Team_Website.Services.Interfaces
{
    public interface ISponsorService
    {
        List<Sponsor> GetSponsors();
        Sponsor GetSponsorById(int id);
        void AddSponsor(Sponsor sponsor);
        void UpdateSponsor(Sponsor sponsor);
        void DeleteSponsor(int id);
    }
}