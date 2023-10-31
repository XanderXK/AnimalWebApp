namespace AnimalWebApp.Models.ViewModels;

public class AnimalPostDetails
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public required string Author { get; set; }
    public bool Visible { get; set; }
    public int LikeCount { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}