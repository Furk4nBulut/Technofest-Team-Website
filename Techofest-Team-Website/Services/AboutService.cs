using Techonefest_Team_Website.Data;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;
using System.Linq;

namespace Techonefest_Team_Website.Services
{
    public class AboutService : IAboutService
    {
        private readonly ApplicationDbContext _context;

        public AboutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public About GetAboutInfo()
        {
            return _context.Abouts.FirstOrDefault() ?? new About();
        }

        public void UpdateAbout(About about)
        {
            var existing = _context.Abouts.FirstOrDefault();

            if (existing != null)
            {
                existing.Title = about.Title;
                existing.Content = about.Content;
                _context.Abouts.Update(existing);
            }
            else
            {
                _context.Abouts.Add(about);
            }

            _context.SaveChanges();
        }
    }
}