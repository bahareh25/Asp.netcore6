

using myCourseStore.BLL.Framework;
using myCourseStore.DAL.DBContexts;
using myCourseStore.Model.Tags.Commands;
using myCourseStore.Model.Tags.Entities;

namespace myCourseStore.BLL.Tags.Commands;

public class CreateTagHandler : BaseApplicationServiceHandler<CreateTag, Tag>
{
    public CreateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new()
        {
            TagName = request.TagName
        };
        await _courseStoreDbContext.Tags.AddAsync(tag);
        await _courseStoreDbContext.SaveChangesAsync();
        AddResult(tag);
    }
}



