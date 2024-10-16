using GSService;

namespace GSSend
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger,IServiceProvider serviceProvider)
        {
            _logger = logger;
          _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scop = _serviceProvider.CreateScope())
                {
                    var onlineCommandService = scop.ServiceProvider.GetRequiredService<OnlineCommandService>();
                    onlineCommandService.SendData(CancellationToken.None);
                    onlineCommandService.RecieveData(CancellationToken.None);
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}