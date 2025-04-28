using System.ComponentModel.DataAnnotations;

namespace Techonefest_Team_Website.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}