using AnimalWebApp.Data;
using AnimalWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AnimalWebApp.Repositories;

public class UserRepository : IUserRepository
{
    private const string SuperAdminId = "0";
    private readonly AuthDbContext _authDbContext;
    private readonly UserManager<IdentityUser> _userManager;


    public UserRepository(AuthDbContext authDbContext, UserManager<IdentityUser> userManager)
    {
        _authDbContext = authDbContext;
        _userManager = userManager;
    }

    public ICollection<IdentityUser> GetAll()
    {
        var users = _authDbContext.Users.ToList();
        users.RemoveAll(user => user.Id == SuperAdminId);
        return users;
    }

    public async Task<bool> AddAsync(AddUser addUser)
    {
        var identityUser = new IdentityUser
        {
            UserName = addUser.Name,
            Email = addUser.Email
        };

        var result = await _userManager.CreateAsync(identityUser, addUser.Password);
        if (!result.Succeeded)
        {
            return false;
        }

        await _userManager.AddToRoleAsync(identityUser, "User");
        if (addUser.IsAdmin)
        {
            await _userManager.AddToRoleAsync(identityUser, "Admin");
        }

        return true;
    }

    public async Task<bool> Delete(string id)
    {
        var identityUser = _userManager.Users.FirstOrDefault(iu => iu.Id == id);
        if (identityUser == null)
        {
            return false;
        }

        await _userManager.DeleteAsync(identityUser);
        return true;
    }
}