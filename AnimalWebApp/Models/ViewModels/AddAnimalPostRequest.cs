using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalWebApp.Models.ViewModels;

public class AddAnimalPostRequest
{
    public string Heading { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string HandleUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool Visible { get; set; }

    public List<string> SelectedTags { get; set; } = new();
    public IEnumerable<SelectListItem> Tags { get; set; }
}