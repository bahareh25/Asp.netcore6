using Microsoft.AspNetCore.Mvc.Filters;

namespace MyFiltersSample.Filters;
public class DiFillterAttribute:ActionFilterAttribute
{
    private readonly ILogger<DiFillterAttribute> _logger;
    public DiFillterAttribute(ILogger<DiFillterAttribute> logger)
    {
        _logger = logger;
       
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Logger Sample");
    }
}
public class MyGuidAttribute : ActionFilterAttribute
{
    private readonly Guid _guid=Guid.NewGuid();
    //public string Name { get; set; }
    //public MyGuidAttribute(string name)
    //{
    //    Name = name;
    //}
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Console.WriteLine($"{Name}:{_guid}");
        Console.WriteLine($"{_guid}");
    }
}

