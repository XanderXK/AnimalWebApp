﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnimalWebApp.Models;
using AnimalWebApp.Models.ViewModels;
using AnimalWebApp.Repositories;

namespace AnimalWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IAnimalPostRepository _animalPostRepository;
    private readonly ITagRepository _tagRepository;


    public HomeController(IAnimalPostRepository animalPostRepository, ITagRepository tagRepository)
    {
        _animalPostRepository = animalPostRepository;
        _tagRepository = tagRepository;
    }
    
    public IActionResult Index()
    {
        var posts = _animalPostRepository.GetAll();
        var tags = _tagRepository.GetAll();
        var homeViewModel = new HomeViewWrapper(posts, tags);
        return View(homeViewModel);
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