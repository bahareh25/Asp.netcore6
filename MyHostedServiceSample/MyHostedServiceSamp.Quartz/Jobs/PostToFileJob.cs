using MyHostedServiceSamp.Quartz.Models;
using Newtonsoft.Json;
using Quartz;

namespace MyHostedServiceSamp.Quartz.Jobs
{
    public class PostToFileJob : IJob
    {
        private readonly PostService _postService;

        public PostToFileJob(PostService postService)
        {
            _postService = postService;
        }



        public async Task Execute(IJobExecutionContext context)
        {
            var posts = await _postService.GetAll();
            System.IO.File.WriteAllText($"F:\\Temp\\{DateTime.Now.Ticks}.json", JsonConvert.SerializeObject(posts));
        }
    }
}
