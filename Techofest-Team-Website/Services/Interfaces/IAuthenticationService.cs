using System.Threading.Tasks;
using Techonefest_Team_Website.Models;

namespace Techonefest_Team_Website.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<User> GetCurrentUserAsync();
    }
}