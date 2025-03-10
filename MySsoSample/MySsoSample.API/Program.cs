var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization(c =>
{
    c.AddPolicy("MyApi", policy =>
     {
         policy.RequireAuthenticatedUser();
         policy.RequireClaim("Scope", "api1");
     });
});
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", Options => {
    Options.Authority = "https://localhost:7003";
    Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    { ValidateAudience = false, };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("MyApi");

app.Run();
