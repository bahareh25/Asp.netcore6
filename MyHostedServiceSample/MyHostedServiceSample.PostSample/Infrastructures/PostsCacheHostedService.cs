using MyHostedServiceSample.PostSample.Models;

namespace MyHostedServiceSample.PostSample.Infrastructures
{
    public class PostsCacheHostedService : BackgroundService
    {
        private readonly PostCache _postCache;
        private  readonly IServiceProvider _serviceProvider;

        public PostsCacheHostedService(PostCache postCache,IServiceProvider serviceProvider )
        {
            _postCache = postCache;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           while(!stoppingToken.IsCancellationRequested)
            {
                using(var scop=_serviceProvider.CreateScope())
                { var postService=scop.ServiceProvider.GetRequiredService<PostService>();
                    var posts = await postService.GetAll();
                    _postCache.Set(posts);
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                                              
            }
        }
    }
}
