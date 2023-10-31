namespace AnimalWebApp.Models.ViewModels;

public class EditTagRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string DisplayName { get; set; }
}