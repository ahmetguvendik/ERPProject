using Application.Features.Queries.JobTypeQueries;
using Application.Features.Results.JobTypeResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class JobTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobTypeController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var values = await _mediator.Send(new GetJobTypeQuery());
        return Ok(values);
    }
}