using MyRestSamples.Model;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDBContext>();
var app = builder.Build();
app.MapGet("/GetProductList",async (HttpContext context,ProductDBContext dbContext) =>
{
    var productList=dbContext.Products.ToList();
    var productListString=JsonConvert.SerializeObject(productList);
    context.Response.StatusCode = 200;
    await context.Response.WriteAsJsonAsync(productListString);
} );
//app.MapGet("/", () => "Hello World!");

app.Run();
