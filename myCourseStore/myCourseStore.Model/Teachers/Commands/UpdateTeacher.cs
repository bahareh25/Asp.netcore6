
using myCourseStore.Model.Teachers.Entities;
using MediatR;
using myCourseStore.Model.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCourseStore.Model.Teachers.Commands
{
  public class UpdateTeacher:IRequest<ApplicationServiceResponse<Teacher>>
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
