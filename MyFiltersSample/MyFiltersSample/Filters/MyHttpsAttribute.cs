using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFiltersSample.Filters
{
    public class MyHttpsAttribute :Attribute, IAuthorizationFilter //,IAsyncAuthorizationFilter

    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            { 
             context.Result=new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }

        //public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
