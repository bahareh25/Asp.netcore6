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
    public class UpdateTeacherHandler : BaseApplicationServiceHandler<UpdateTeacher, Teacher>
    {
        public UpdateTeacherHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
        {
        }

        protected override async Task HandleRequest(UpdateTeacher request, CancellationToken cancellationToken)
        {
            Teacher teacher = _courseStoreDbContext.Teachers.SingleOrDefault(c => c.Id == request.Id);
            if (teacher == null)
            {
                AddError($"معلم با شناسه {request.Id} یافت نشد");

            }
           else
            {
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                await _courseStoreDbContext.SaveChangesAsync();
                AddResult(teacher);
            }
        }
    }
}
