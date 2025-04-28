using System.Collections.Generic;
using System.Linq;
using Techonefest_Team_Website.Data;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ApplicationDbContext _context;

        public SponsorService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Sponsorları listele
        public List<Sponsor> GetSponsors()
        {
            return _context.Sponsors.ToList();
        }

        // Sponsor ID ile sponsor getirme
        public Sponsor GetSponsorById(int id)
        {
            return _context.Sponsors.FirstOrDefault(s => s.Id == id);
        }

        // Yeni sponsor ekleme
        public void AddSponsor(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            _context.SaveChanges();
        }

        // Sponsor güncelleme
        public void UpdateSponsor(Sponsor sponsor)
        {
            _context.Sponsors.Update(sponsor);
            _context.SaveChanges();
        }

        // Sponsor silme
        public void DeleteSponsor(int id)
        {
            var sponsor = _context.Sponsors.FirstOrDefault(s => s.Id == id);
            if (sponsor != null)
            {
                _context.Sponsors.Remove(sponsor);
                _context.SaveChanges();
            }
        }
    }
}