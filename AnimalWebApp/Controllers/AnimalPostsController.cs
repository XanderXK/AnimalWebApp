using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalWebApp.Controllers;

public class AnimalPostsController : Controller
{
    private readonly ITagRepository _tagRepository;
    private readonly IAnimalPostRepository _animalPostRepository;

    public AnimalPostsController(ITagRepository tagRepository, IAnimalPostRepository animalPostRepository)
    {
        _tagRepository = tagRepository;
        _animalPostRepository = animalPostRepository;
    }

    [HttpGet]
    public IActionResult Add()
    {
        var tags = _tagRepository.GetAll();
        var addAnimalPostRequest = new AddAnimalPostRequest
        {
            Tags = tags.Select(tag => new SelectListItem
            {
                Text = tag.DisplayName,
                Value = tag.Id.ToString()
            })
        };

        return View(addAnimalPostRequest);
    }

    [HttpPost]
    public IActionResult Add(AddAnimalPostRequest addAnimalPostRequest)
    {
        Console.WriteLine(addAnimalPostRequest);
        return View(addAnimalPostRequest);
    }
}