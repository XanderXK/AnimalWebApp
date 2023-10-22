using AnimalWebApp.Models;
using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikeController : Controller
{
    private readonly ILikeRepository _likeRepository;

    public LikeController(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    [HttpPost("Add")]
    public IActionResult Add(Like like)
    {
        var result = _likeRepository.AddLike(like);
        if (!result)
        {
            return BadRequest(ModelState);
        }

        return Ok();
    }
}