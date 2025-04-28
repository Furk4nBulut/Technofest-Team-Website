using System.ComponentModel.DataAnnotations;

namespace Techonefest_Team_Website.Models
{
public class Service
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public string IconPath { get; set; }
}
}