using myCourseStore.Model.Framework;
using myCourseStore.Model.Tags.Dtos;
using MediatR;

namespace myCourseStore.Model.Tags.Queries;

public class FilterByName:IRequest<ApplicationServiceResponse<List<TagQr>>>
{
    public string? TagName { get; set; }
}