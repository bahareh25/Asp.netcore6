using Microsoft.AspNetCore.Mvc;
using MyViewComponentSample.Models;

namespace MyViewComponentSample.Components
{
    public class NewsList: ViewComponent
    {
        private readonly NewsDbContext _newsDbContext;

        public NewsList(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }
        public IViewComponentResult Invoke(string viewname)
        {
            var newsList=_newsDbContext.News.ToList();
            return View("MyNews",newsList);
            return View(viewname, newsList);
        }
    }
}
