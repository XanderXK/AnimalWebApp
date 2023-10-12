namespace AnimalWebApp.Models;

public class AnimalPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string HandleUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool Visible { get; set; }

    public ICollection<Tag> Tags { get; set; }
}