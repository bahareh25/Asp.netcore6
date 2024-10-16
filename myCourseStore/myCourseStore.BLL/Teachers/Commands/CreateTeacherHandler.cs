using myCourseStore.BLL.Framework;
using myCourseStore.DAL.DBContexts;
using myCourseStore.Model.Teachers.Commands;
using myCourseStore.Model.Teachers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCourseStore.BLL.Teachers.Commands
{
    public class CreateTeacherHandler : BaseApplicationServiceHandler<CreateTeacher, Teacher>
    {
        public CreateTeacherHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {
        }

        protected override async Task HandleRequest(CreateTeacher request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            await _courseStoreDbContext.Teachers.AddAsync(teacher);
            await _courseStoreDbContext.SaveChangesAsync();
           AddResult(teacher);
        }
    }
}
