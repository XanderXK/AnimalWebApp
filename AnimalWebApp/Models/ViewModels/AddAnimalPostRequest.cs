using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalWebApp.Models.ViewModels;

public class AddAnimalPostRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public required string Author { get; set; }
    public bool Visible { get; set; }

    public List<string> SelectedTags { get; set; } = new();
    public List<SelectListItem> Tags { get; set; } = new();
}