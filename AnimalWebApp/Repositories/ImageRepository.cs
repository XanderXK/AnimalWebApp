using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace AnimalWebApp.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly Account _account;


    public ImageRepository(IConfiguration configuration)
    {
        var cloudinaryConfig = configuration.GetSection("Cloudinary");
        _account = new Account(cloudinaryConfig["CloudName"], cloudinaryConfig["ApiKey"], cloudinaryConfig["ApiSecret"]);
    }

    public string? Upload(IFormFile file)
    {
        var cloudinary = new Cloudinary(_account);
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
            DisplayName = file.FileName
        };

        var result = cloudinary.Upload(uploadParams);
        if (result == null || result.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        return result.SecureUrl.ToString();
    }
}