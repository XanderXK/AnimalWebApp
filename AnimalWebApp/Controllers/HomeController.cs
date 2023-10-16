using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnimalWebApp.Models;
using AnimalWebApp.Repositories;

namespace AnimalWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IAnimalPostRepository _animalPostRepository;


    public HomeController(IAnimalPostRepository animalPostRepository)
    {
        _animalPostRepository = animalPostRepository;
    }
    
    public IActionResult Index()
    {
        var posts = _animalPostRepository.GetAll();
        return View(posts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}