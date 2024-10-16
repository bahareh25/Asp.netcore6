using GSSend;
using GSService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
       
        services.AddSingleton<OnlineCommandService>();
        services.AddSingleton<SendService>();
        services.AddSingleton<GSConnection>();
        services.AddSingleton<GSRecieveService>();
        services.AddHostedService<Worker>();

    })
    .Build();
await host.RunAsync();
