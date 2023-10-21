namespace AnimalWebApp.Models.ViewModels;

public class LoginUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? ReturnUrl { get; set; }
}