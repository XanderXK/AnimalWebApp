using AnimalWebApp.Data;
using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AdminTagsController : Controller
{
    private readonly IConfiguration _configuration;

    public AdminTagsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTagRequest addTagRequest)
    {
        var dataContext = new DataContext(_configuration);
        var sql = $"INSERT INTO Tags (Name, DisplayName) VALUES ('{addTagRequest.Name}', '{addTagRequest.DisplayName}')";
        var result = dataContext.Execute(sql);
        if (!result)
        {
            return BadRequest(ModelState);
        }

        return RedirectToAction(nameof(TagList));
    }

    [HttpGet]
    public IActionResult TagList()
    {
        var dataContext = new DataContext(_configuration);
        var sql = $"SELECT * FROM Tags";
        var tags = dataContext.LoadData<Tag>(sql).ToList();
        return View(tags);
    }
}