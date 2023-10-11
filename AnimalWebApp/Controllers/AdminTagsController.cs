using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AdminTagsController : Controller
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;


    public AdminTagsController(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTagRequest addTagRequest)
    {
        var tag = _mapper.Map<Tag>(addTagRequest);
        var result = _tagRepository.Add(tag);
        if (!result)
        {
            return BadRequest(ModelState);
        }

        return RedirectToAction(nameof(TagList));
    }

    [HttpGet]
    public IActionResult TagList()
    {
        var tags = _tagRepository.GetAll();
        return View(tags);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var tag = _tagRepository.Get(id);
        var editTag = _mapper.Map<EditTagRequest>(tag);
        return View(editTag);
    }

    [HttpPost]
    public IActionResult Edit(EditTagRequest editTagRequest)
    {
        var tag = _mapper.Map<Tag>(editTagRequest);
        var result = _tagRepository.Update(tag);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { id = editTagRequest.Id });
        }

        return RedirectToAction(nameof(TagList));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _tagRepository.Delete(id);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { id });
        }

        return RedirectToAction(nameof(TagList));
    }
}