using MyViewComponentSample.Models;

namespace MyViewComponentSample.Components
{
    public class FirstPocoViewComponent
    {
        private readonly NewsDbContext _newsDbContext;

        public FirstPocoViewComponent(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }
        public string Invoke()
        {
            string _newDescription = _newsDbContext.News.Where(c => c.Id == 3).FirstOrDefault().Description;
            return _newDescription;
        }
    }
}
