using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : Controller
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        var url = _imageRepository.Upload(file);
        if (url == null)
        {
            return Problem("null");
        }

        return new JsonResult(new { link = url });
    }
}