using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFiltersSample.Filters;

public class CacheItem
{
    public DateTime CreateDate { get; set; }
    public IActionResult result { get; set; }
}
public class MyCacheAttribute : Attribute, IResourceFilter
{
    public static Dictionary<string, CacheItem> Caches {get;set;}=new Dictionary<string, CacheItem>();

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        if (!Caches.ContainsKey(context.HttpContext.Request.Path))
        {
            Caches[context.HttpContext.Request.Path] = new CacheItem
            {
                CreateDate = DateTime.Now,
                result = context.Result
            };
        }
    }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        if (Caches.ContainsKey(context.HttpContext.Request.Path))
        {
            var item = Caches[context.HttpContext.Request.Path];
            if (item.CreateDate >= DateTime.Now.AddSeconds(-10))
            {
                context.Result = item.result;
            }
            else
            { Caches.Remove(context.HttpContext.Request.Path); }
        }
   
        }
    }
