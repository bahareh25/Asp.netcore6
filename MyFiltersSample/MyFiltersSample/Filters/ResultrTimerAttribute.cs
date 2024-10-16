using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyFiltersSample.Filters;

public class ResultrTimerAttribute : ResultFilterAttribute
{
    private readonly Stopwatch _stopWatch = new();
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        _stopWatch.Start();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName}Start Executing");

    }
    public override void OnResultExecuted(ResultExecutedContext context)
    {
        _stopWatch.Stop();
        Console.WriteLine($"Action {context.ActionDescriptor.DisplayName}Start Executed.time:{_stopWatch.ElapsedMilliseconds}");
    }
}