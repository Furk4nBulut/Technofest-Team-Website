using System.Collections.Generic;
using Techonefest_Team_Website.Models;

namespace Techonefest_Team_Website.Services.Interfaces
{
    public interface IServiceService
    {
        List<Service> GetServices();
        Service GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);
    }
}