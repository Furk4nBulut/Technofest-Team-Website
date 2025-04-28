using System.ComponentModel.DataAnnotations;

namespace Techonefest_Team_Website.Models
{
    public class Sponsor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LogoPath { get; set; }
        public string Url { get; set; }
    }
}