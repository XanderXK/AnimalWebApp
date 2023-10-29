using AnimalWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AnimalWebApp.Repositories;

public interface IUserRepository
{
    public ICollection<IdentityUser> GetAll();
    public Task<bool> AddAsync(AddUser addUser);
    public Task<bool> Delete(string id);
}