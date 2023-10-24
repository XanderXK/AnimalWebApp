namespace AnimalWebApp.Models;

public class Comment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int AnimalPostId { get; set; }
    public string UserId { get; set; }
}