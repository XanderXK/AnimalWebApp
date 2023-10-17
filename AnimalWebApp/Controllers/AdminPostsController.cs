using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalWebApp.Controllers;

public class AdminPostsController : Controller
{
    private readonly ITagRepository _tagRepository;
    private readonly IAnimalPostRepository _animalPostRepository;
    private readonly IMapper _mapper;

    public AdminPostsController(ITagRepository tagRepository, IAnimalPostRepository animalPostRepository, IMapper mapper)
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
        var tagIds = addAnimalPostRequest.SelectedTags.Select(int.Parse).ToList();
        _animalPostRepository.Add(animalPost, tagIds);
        return RedirectToAction(nameof(GetAll));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var posts = _animalPostRepository.GetAll();
        return View(posts);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var post = _animalPostRepository.Get(id);
        var editPost = _mapper.Map<EditAnimalPostRequest>(post);
        return View(editPost);
    }

    [HttpPost]
    public IActionResult Edit(EditAnimalPostRequest editAnimalPost)
    {
        var post = _mapper.Map<AnimalPost>(editAnimalPost);
        var result = _animalPostRepository.Update(post);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { editAnimalPost.Id });
        }

        return RedirectToAction(nameof(GetAll));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _animalPostRepository.Delete(id);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { id });
        }

        return RedirectToAction(nameof(GetAll));
    }
}