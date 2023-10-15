namespace AnimalWebApp.Repositories;

public interface IImageRepository
{
    public string? Upload(IFormFile file);
}