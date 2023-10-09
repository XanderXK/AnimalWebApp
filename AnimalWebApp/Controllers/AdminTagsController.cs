using AnimalWebApp.Data;
using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AdminTagsController : Controller
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public AdminTagsController(IConfiguration configuration, IMapper mapper)
    {
        _mapper = mapper;
        _dataContext = new DataContext(configuration);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTagRequest addTagRequest)
    {
        var sql = $"INSERT INTO Tags (Name, DisplayName) VALUES ('{addTagRequest.Name}', '{addTagRequest.DisplayName}')";
        var result = _dataContext.Execute(sql);
        if (!result)
        {
            return BadRequest(ModelState);
        }

        return RedirectToAction(nameof(TagList));
    }

    [HttpGet]
    public IActionResult TagList()
    {
        var sql = $"SELECT * FROM Tags";
        var tags = _dataContext.LoadData<Tag>(sql);
        return View(tags);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var sql = $"SELECT * FROM TAGS WHERE Id={id}";
        var tag = _dataContext.LoadSingleData<Tag>(sql);
        var editTag = _mapper.Map<EditTagRequest>(tag);
        return View(editTag);
    }

    [HttpPost]
    public IActionResult Edit(EditTagRequest editTagRequest)
    {
        var sql = $"UPDATE Tags Set Name='{editTagRequest.Name}', DisplayName= '{editTagRequest.DisplayName}' WHERE Id={editTagRequest.Id}";
        var result = _dataContext.Execute(sql);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { id = editTagRequest.Id });
        }

        return RedirectToAction(nameof(TagList));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var sql = $"DELETE FROM Tags WHERE Id={id}";
        var result = _dataContext.Execute(sql);
        if (!result)
        {
            return RedirectToAction(nameof(Edit), new { id = id });
        }

        return RedirectToAction(nameof(TagList));
    }
}