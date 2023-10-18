using Microsoft.AspNetCore.Identity;

namespace AnimalWebApp.Data;

public class AuthStore: IUserStore<IdentityUser> , IRoleStore<IdentityRole>
{
    public AuthStore()
    {
        var roles = new List<IdentityRole>
        {
            new() { Name = "SuperAdmin", NormalizedName = "SuperAdmin", Id = "0", ConcurrencyStamp = "0" },
            new() { Name = "Admin", NormalizedName = "Admin", Id = "1", ConcurrencyStamp = "1" },
            new() { Name = "User", NormalizedName = "User", Id = "2", ConcurrencyStamp = "2" }
        };

        var sAdmin = new IdentityUser()
        {
            Id = "0",
            UserName = "sa",
            NormalizedUserName = "SA",
            Email = "sa@animal.animal",
            NormalizedEmail = "sa@animal.animal".ToUpper()
        };

        sAdmin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(sAdmin, "sa");

        var saRoles = new List<IdentityUserRole<string>>
        {
            new() { RoleId = "0", UserId = "0" },
            new() { RoleId = "1", UserId = "1" },
            new() { RoleId = "2", UserId = "2" }
        };
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(IdentityUser user, string? userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(IdentityUser user, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetRoleNameAsync(IdentityRole role, string? roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedRoleNameAsync(IdentityRole role, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityRole?> IRoleStore<IdentityRole>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityRole?> IRoleStore<IdentityRole>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityUser?> IUserStore<IdentityUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityUser?> IUserStore<IdentityUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}