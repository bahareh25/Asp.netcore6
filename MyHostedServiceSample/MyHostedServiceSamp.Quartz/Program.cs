using MyHostedServiceSamp.Quartz.Jobs;
using MyHostedServiceSamp.Quartz.Models;
using Quartz;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<PostService>();
builder.Services.AddQuartz(c =>
{
    c.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("Post To File");
    c.AddJob<PostToFileJob>(j=>j.WithIdentity(jobKey));
    c.AddTrigger(t => t.ForJob(jobKey).WithIdentity("Post ToFile Trigger")
    .StartNow().WithSimpleSchedule(sc => sc.WithInterval(TimeSpan.FromSeconds(30)).RepeatForever()));
    
});
builder.Services.AddQuartzHostedService(c =>
{
    c.WaitForJobsToComplete = true;
});
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
