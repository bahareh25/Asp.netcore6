

using myCourseStore.BLL.Framework;
using myCourseStore.DAL.DBContexts;
using myCourseStore.Model.Tags.Commands;
using myCourseStore.Model.Tags.Entities;

namespace myCourseStore.BLL.Tags.Commands;

public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag, Tag>
{
    public UpdateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }
    protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
    {
        Tag tag = _courseStoreDbContext.Tags.SingleOrDefault(c => c.Id == request.Id);
        if (tag == null)
        {
            AddError($"تگ با شناسه {request.Id} یافت نشد");
        }
        else
        {
            tag.TagName = request.TagName;
            await _courseStoreDbContext.SaveChangesAsync();
            AddResult(tag);
        }
    }
}



