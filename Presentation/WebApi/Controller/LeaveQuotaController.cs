using Application.Features.Queries.LeaveQuotaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")] 
[ApiController]
public class LeaveQuotaController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveQuotaController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id) 
    {
        var value = await _mediator.Send(new GetLeaveQuotaQuery(id));
        return Ok(value);
    }
}