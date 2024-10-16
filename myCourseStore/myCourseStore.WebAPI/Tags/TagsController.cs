using myCourseStore.Model.Tags.Commands;
using myCourseStore.Model.Tags.Queries;
using myCourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace myCourseStore.WebAPI.Tags;

public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateTag")]
    public async Task<IActionResult> CreateTag(CreateTag tag)
    {
        var response = await _mediator.Send(tag);
     
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("UpdateTag")]
    public async Task<IActionResult> UpdateTag(UpdateTag tag)
    {
        var response = await _mediator.Send(tag);
       
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }


    [HttpGet("FilterByName")]
    public async Task<IActionResult> SearchTag([FromQuery]FilterByName tag)
    {
        var response = await _mediator.Send(tag);
      
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
