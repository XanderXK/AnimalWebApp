namespace AnimalWebApp.Models;

public class Comment
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public int AnimalPostId { get; set; }
    public required string UserId { get; set; }
}