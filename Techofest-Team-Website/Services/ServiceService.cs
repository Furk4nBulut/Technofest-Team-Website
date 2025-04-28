using System.Collections.Generic;
using System.Linq;
using Techonefest_Team_Website.Data;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services.Interfaces;

namespace Techonefest_Team_Website.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;

        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.Id == id);
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}