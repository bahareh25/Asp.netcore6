using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyAAASample.Infra;
using MyAAASample.Models;
using MyAAASample.Requirements;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddMvc();
//builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,opts=>{
//    opts.LoginPath = "/Authiticate";
//    opts.AccessDeniedPath = "/NotAllowed"; });
builder.Services.AddSingleton<IAuthorizationHandler, AgePolicyRequirementHandler>();
builder.Services.AddDbContext<MyAAADBContext>(c=> c.UseSqlServer("Server=.; Initial Catalog=AAADb1; User ID=sa; Password=123"));
builder.Services.AddIdentity<CostumIdentityUser, IdentityRole>(c =>
{
    //c.Password.RequiredLength = 4;
    //c.Password.RequiredUniqueChars = 2;
    //c.Password.RequireNonAlphanumeric = false;
    //c.Password.RequireUppercase = false;
    //c.Password.RequireLowercase= false;
    //c.Password.RequireDigit = false;
    c.User.AllowedUserNameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
    c.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MyAAADBContext>().AddUserValidator<CostumUserValidator>();
//.AddPasswordValidator<UsernameInPasswordValidator>();

builder.Services.Configure<IdentityOptions>(c => { });
builder.Services.AddAuthorization(c =>
{
    c.AddPolicy("IsAdmin", pb =>{ pb.RequireRole("Admin").RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "Bahar", "Alireza"); });
    c.AddPolicy("IsMoreThan18", pb =>
     { pb.Requirements.Add(new AgePolicyRequirement(18)); });
});
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
