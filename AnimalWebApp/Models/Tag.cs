namespace AnimalWebApp.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }

    public ICollection<AnimalPost> Posts { get; set; }
}