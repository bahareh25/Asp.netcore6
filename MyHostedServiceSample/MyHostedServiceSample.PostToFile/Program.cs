using MyHostedServiceSample.PostToFile;
using MyHostedServiceSample.PostToFile.Models;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient<PostService>();
        services.AddHostedService<Worker>();
    }).UseWindowsService()
    .Build();

await host.RunAsync();
