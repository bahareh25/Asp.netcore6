using MyFiltersSample.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddMvcOptions(c =>
{
    c.Filters.Add<MyHttpsAttribute>();//globalfilter
    c.Filters.Add(new FilterOrderAttribute("Golobal Filter"));
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<MyGuidAttribute>();
var app = builder.Build();
app.UseStatusCodePages();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();
//app.MapGet("/", () => "Hello World!");

app.Run();
