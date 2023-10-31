namespace AnimalWebApp.Models.ViewModels;

public class EditAnimalPostRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string Author { get; set; }
    public bool Visible { get; set; }
}