using AnimalWebApp.Data;
using AnimalWebApp.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddUserStore<AuthStore>().AddRoleStore<AuthStore>();

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IAnimalPostRepository, AnimalPostRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute
(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();