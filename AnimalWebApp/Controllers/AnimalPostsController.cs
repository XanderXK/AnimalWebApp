using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AnimalPostsController: Controller
{
    private readonly IAnimalPostRepository _animalPostRepository;

    public AnimalPostsController( IAnimalPostRepository animalPostRepository)
    {
        _animalPostRepository = animalPostRepository;
    }
    
    
    [HttpGet]
    public IActionResult Index(int id)
    {
        var post = _animalPostRepository.Get(id);
        return View(post);
    }
}