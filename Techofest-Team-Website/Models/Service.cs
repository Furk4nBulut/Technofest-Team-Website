using System.ComponentModel.DataAnnotations;

public class Service
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    public string IconPath { get; set; }
}