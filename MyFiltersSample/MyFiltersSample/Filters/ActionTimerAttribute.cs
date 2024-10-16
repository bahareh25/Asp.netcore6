using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyFiltersSample.Filters;
public class FilterOrderAttribute:ActionFilterAttribute
{
public string Name { get; set; }
    public FilterOrderAttribute(string name)
    {
        Name = name;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
       Console.WriteLine(Name+" Executing");
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
      Console.WriteLine(Name+" Executed");
    }
}
public class ActionTimerAttribute:ActionFilterAttribute
{
    private readonly Stopwatch _stopWatch=new();
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _stopWatch.Stop();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName}Start Executed.time:{_stopWatch.ElapsedMilliseconds}");
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopWatch.Start();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName}Start Executing");
        
    }
}

