using MyViewComponentSample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); 
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NewsDbContext>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
