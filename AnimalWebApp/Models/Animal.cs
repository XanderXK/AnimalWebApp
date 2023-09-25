namespace AnimalWebApp.Models;

public class Animal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public required int CategoryId { get; set; }
    public int OwnerId { get; set; }
}