using Microsoft.AspNetCore.Mvc;
using MyRestSamples.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDBContext>();
builder.Services.Configure<JsonOptions>(c =>
{
    c.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
var app = builder.Build();

app.MapControllers();
app.Run();
