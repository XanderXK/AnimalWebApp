using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalWebApp.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("auth");
        
        var roles = new List<IdentityRole>
        {
            new() { Name = "SuperAdmin", NormalizedName = "SuperAdmin", Id = "0", ConcurrencyStamp = "0" },
            new() { Name = "Admin", NormalizedName = "Admin", Id = "1", ConcurrencyStamp = "1" },
            new() { Name = "User", NormalizedName = "User", Id = "2", ConcurrencyStamp = "2" }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var sAdmin = new IdentityUser()
        {
            Id = "0",
            UserName = "sa",
            NormalizedUserName = "SA",
            Email = "sa@animal.animal",
            NormalizedEmail = "sa@animal.animal".ToUpper()
        };

        sAdmin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(sAdmin, "sa");

        builder.Entity<IdentityUser>().HasData(sAdmin);

        var saRoles = new List<IdentityUserRole<string>>
        {
            new() { RoleId = "0", UserId = "0" },
            new() { RoleId = "1", UserId = "0" },
            new() { RoleId = "2", UserId = "0" }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(saRoles);
    }
}