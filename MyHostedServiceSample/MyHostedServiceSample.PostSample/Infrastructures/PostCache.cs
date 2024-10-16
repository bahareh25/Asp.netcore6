using MyHostedServiceSample.PostSample.Models;

namespace MyHostedServiceSample.PostSample.Infrastructures
{
    public class PostCache
    {
        private List<Post> _posts;
        public List<Post> Get()
        {
            return _posts;
        }


        public void Set(List<Post> posts)
        {
            Interlocked.Exchange(ref _posts, posts);
        }

    }
}
