using myCourseStore.Model.Teachers.Commands;
using myCourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using myCourseStoreModel.Teachers.Queries;

namespace myCourseStore.WebAPI.Teachers
{

    public class TeachersController : BaseController

    {
        public TeachersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(CreateTeacher createTeacher)
        {
            var response=await _mediator.Send(createTeacher);
            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpsateTeacher(UpdateTeacher updateTeacher)
        {
            var response = await _mediator.Send(updateTeacher);
            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }

        [HttpGet("FilterByName")]
        public async Task<IActionResult> SearchTeacherByName([FromQuery] FilterByName teacher )
        {
          var response=await  _mediator.Send(teacher);
            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }
    }
}
