using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalWebApp.Controllers;

public class AnimalPostsController : Controller
{
    private readonly ITagRepository _tagRepository;
    private readonly IAnimalPostRepository _animalPostRepository;
    private readonly IMapper _mapper;

    public AnimalPostsController(ITagRepository tagRepository, IAnimalPostRepository animalPostRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _animalPostRepository = animalPostRepository;
        _mapper = mapper;
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
        var animalPost = _mapper.Map<AnimalPost>(addAnimalPostRequest);
        animalPost.Tags = _tagRepository.GetAll()
            .Where(tag => addAnimalPostRequest.SelectedTags.Contains(tag.Id.ToString())).ToList();
        _animalPostRepository.Add(animalPost);
        return View(addAnimalPostRequest);
    }
}