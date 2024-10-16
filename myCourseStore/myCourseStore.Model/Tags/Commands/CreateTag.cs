using myCourseStore.Model.Framework;
using myCourseStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace myCourseStore.Model.Tags.Commands;

public class CreateTag : IRequest<ApplicationServiceResponse<Tag>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}
