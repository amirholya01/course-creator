using CourseCreator.Core.Services;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Access the connection string
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<CourseCreatorContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<IUserService, UserService>(); //Ioc
builder.Services.AddControllersWithViews();
//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
   // options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});
builder.Services.AddRazorPages();
var app = builder.Build();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "admin",
//        pattern: "admin/{controller=Admin}/{action=Index}/{id?}");

//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
app.UseStaticFiles();
app.UseAuthentication();
app.MapDefaultControllerRoute();
app.MapRazorPages();
//app.MapGet("/", () => "Hello World!");

app.Run();
