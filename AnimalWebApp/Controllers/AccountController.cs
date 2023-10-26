using AnimalWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login(string ReturnUrl)
    {
        var loginUser = new LoginUser { ReturnUrl = ReturnUrl };
        return View(loginUser);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);
        if (result.Succeeded)
        {
            if (!string.IsNullOrWhiteSpace(loginUser.ReturnUrl))
            {
                return Redirect(loginUser.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}