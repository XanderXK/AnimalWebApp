using AnimalWebApp.Models;
using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

[Authorize(Roles = "Admin")]
public class AdminUsersController : Controller
{
    private readonly IUserRepository _userRepository;


    public AdminUsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult GetAll()
    {
        var users = _userRepository.GetAll();
        return View(users);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddUser addUser)
    {
        var result = await _userRepository.AddAsync(addUser);
        if (!result)
        {
            return RedirectToAction(nameof(Add));
        }

        return RedirectToAction(nameof(GetAll));
    }

    [HttpPost]
    public IActionResult Delete(string id)
    {
        _userRepository.Delete(id);
        return RedirectToAction(nameof(GetAll));
    }
}