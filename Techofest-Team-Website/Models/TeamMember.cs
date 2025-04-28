using System.ComponentModel.DataAnnotations;

public class TeamMember
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Role { get; set; }
    public string ImagePath { get; set; }
    public string Bio { get; set; }
}