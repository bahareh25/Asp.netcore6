using Microsoft.EntityFrameworkCore;
using MyAsp6Store.ShopUI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StorCnn");
builder.Services.AddDbContext<StorDbContext>(options=>options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Bascket>(c=>SessionBascket.GetBascket(c));
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/Page{pageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{pageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
    endpoints.MapDefaultControllerRoute();
}) ;
//"{contoller=home}/{Action=index}/{id?}"

app.Run();
