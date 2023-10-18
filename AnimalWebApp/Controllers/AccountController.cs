using AnimalWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUser registerUser)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerUser.UserName,
            Email = registerUser.Email
        };


        var result = await _userManager.CreateAsync(identityUser, registerUser.Password);
        if (result.Succeeded)
        {
            var resultRole = await _userManager.AddToRoleAsync(identityUser, "User");
            if (resultRole.Succeeded)
            {
                return RedirectToAction(nameof(Register));
            }
        }

        return View();
    }
}