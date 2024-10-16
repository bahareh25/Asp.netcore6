
using myCourseStore.BLL.Framework;
using myCourseStore.DAL.DBContexts;
using myCourseStore.DAL.Tags;
using myCourseStore.Model.Tags.Dtos;
using myCourseStore.Model.Tags.Queries;

namespace myCourseStore.BLL.Tags.Queries;

public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<TagQr>>
{
    public FilterByNameHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
    {
        var result = await _courseStoreDbContext.Tags.WhereOver(request.TagName).ToTagQrAsync();
        AddResult(result);
    }
}