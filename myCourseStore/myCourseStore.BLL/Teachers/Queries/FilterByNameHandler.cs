using myCourseStore.BLL.Framework;
using myCourseStore.Model.Teachers.Dtos;
using myCourseStore.DAL.Teachers;
using myCourseStore.DAL.DBContexts;
using myCourseStoreModel.Teachers.Queries;

namespace myCourseStore.BLL.Teachers.Queries
{
    public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<TeacherQr>>
    {
        public FilterByNameHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {
        }

        protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
        {
            var result = await _courseStoreDbContext.Teachers.Whereover(request.FirstName).Whereover1(request.LastName).ToTeacherQrAsync();
            AddResult(result);
        }
    }
}
