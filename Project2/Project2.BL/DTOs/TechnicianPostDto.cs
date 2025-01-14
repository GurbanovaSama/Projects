namespace Project2.BL.DTOs;

public class TechnicianPostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
