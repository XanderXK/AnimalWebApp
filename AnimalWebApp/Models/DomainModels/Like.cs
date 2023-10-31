namespace AnimalWebApp.Models;

public class Like
{
    public int AnimalPostId { get; set; }
    public required string UserId { get; set; }
}