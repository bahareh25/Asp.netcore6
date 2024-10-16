using myCourseStore.Model.Framework;
using myCourseStore.Model.Teachers.Dtos;
using MediatR;


namespace myCourseStoreModel.Teachers.Queries
{
    public class FilterByName:IRequest<ApplicationServiceResponse<List<TeacherQr>>>
    {
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
    }
}
