using Microsoft.AspNetCore.Identity;

namespace AnimalWebApp.Data;

public class Auth
{
    public Auth()
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
}