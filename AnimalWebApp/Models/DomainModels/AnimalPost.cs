namespace AnimalWebApp.Models;

public class AnimalPost
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public required string Author { get; set; }
    public bool Visible { get; set; }
}