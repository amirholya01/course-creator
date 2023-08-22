using CourseCreator.Core.Services;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.DataLayer.Context;
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
app.MapDefaultControllerRoute();
app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");

app.Run();
