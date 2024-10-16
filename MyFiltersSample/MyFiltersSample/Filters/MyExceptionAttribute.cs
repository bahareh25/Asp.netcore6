using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFiltersSample.Filters;

public class MyExceptionAttribute : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }
}

