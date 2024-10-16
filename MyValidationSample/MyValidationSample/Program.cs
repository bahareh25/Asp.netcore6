using Microsoft.EntityFrameworkCore;
using MyValidationSample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ValidationDbContex>(c => c.UseSqlServer("Server=.;Initial Catalog=ValidationDb; User Id=sa; Password=123;"));
var app = builder.Build();
app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
