using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AnimalPostsController : Controller
{
    private readonly IAnimalPostRepository _animalPostRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;


    public AnimalPostsController(IAnimalPostRepository animalPostRepository, ILikeRepository likeRepository, ICommentRepository commentRepository, IMapper mapper)
    {
        _animalPostRepository = animalPostRepository;
        _likeRepository = likeRepository;
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    [HttpGet("[controller]/{id:int}")]
    public IActionResult Index(int id)
    {
        var post = _animalPostRepository.Get(id);
        var postDetails = _mapper.Map<AnimalPostDetails>(post);
        if (post != null)
        {
            postDetails.LikeCount = _likeRepository.GetLikeCount(post.Id);
            postDetails.Comments = _commentRepository.GetAll();
        }

        return View(postDetails);
    }

    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index), new { id = comment.AnimalPostId });
        }

        _commentRepository.Add(comment);
        return RedirectToAction(nameof(Index), new { id = comment.AnimalPostId });
    }
}