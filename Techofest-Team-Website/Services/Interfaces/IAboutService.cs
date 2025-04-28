using Techonefest_Team_Website.Models;

namespace Techonefest_Team_Website.Services.Interfaces
{
    public interface IAboutService
    {
        About GetAboutInfo();
        void UpdateAbout(About about);
    }
}