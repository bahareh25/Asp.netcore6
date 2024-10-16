using myCourseStore.Model.Framework;
using myCourseStore.Model.Teachers.Entities;
using MediatR;

using System.ComponentModel.DataAnnotations;


namespace myCourseStore.Model.Teachers.Commands
{
 public class CreateTeacher:IRequest<ApplicationServiceResponse<Teacher>>
    {
       [Required]
       [StringLength(200,MinimumLength =2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
