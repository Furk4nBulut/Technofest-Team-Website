using Microsoft.AspNetCore.Identity;

namespace Techonefest_Team_Website.Models
{
    public class User : IdentityUser
    {
        // Ek özellikler eklenebilir, örneğin:
        public string FullName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}