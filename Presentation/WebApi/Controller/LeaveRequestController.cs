using Application.Features.Commands.RequestCommands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[action]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> LeaveRequest(CreateRequestCommand leaveRequest)
    {
        await _mediator.Send(leaveRequest);   
        return Ok("Izin Basarili Bir Sekilde Yollandi");
    }

}