namespace AnimalWebApp.Models;

public class Likes
{
    public int AnimalPostId { get; set; }
    public Guid UserId { get; set; }
}