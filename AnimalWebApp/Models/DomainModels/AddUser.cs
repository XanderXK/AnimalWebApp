namespace AnimalWebApp.Models;

public class AddUser
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }
}