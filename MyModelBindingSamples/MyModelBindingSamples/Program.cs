using Microsoft.EntityFrameworkCore;
using MyModelBindingSamples.Infrastructure;
using MyModelBindingSamples.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyModelBindingContext>(c => c.UseSqlServer("Server=.; Initial Catalog=MBDb; User Id=sa;Password=123;"));
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomeBinderProvider());
});
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
