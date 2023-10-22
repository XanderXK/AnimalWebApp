using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AnimalPostsController : Controller
{
    private readonly IAnimalPostRepository _animalPostRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IMapper _mapper;

    public AnimalPostsController(IAnimalPostRepository animalPostRepository, ILikeRepository likeRepository, IMapper mapper)
    {
        _animalPostRepository = animalPostRepository;
        _likeRepository = likeRepository;
        _mapper = mapper;
    }

    [HttpGet("[controller]/{id:int}")]
    public IActionResult Index(int id)
    {
        var post = _animalPostRepository.Get(id);
        var postDetails = _mapper.Map<AnimalPostDetails>(post);
        if (post != null)
        {
            var likes = _likeRepository.GetLikeCount(post.Id);
            postDetails.LikeCount = likes;
        }

        return View(postDetails);
    }
}