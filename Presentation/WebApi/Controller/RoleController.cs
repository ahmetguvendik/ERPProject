using Application.Features.Queries.AppRoleQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var values = await _mediator.Send(new GetRoleQuery());
        return Ok(values);
    }

    [HttpGet("[action]")]   

    public async Task<IActionResult> GetManagerRole()
    {
        var values = await _mediator.Send(new GetManagerRoleQuery());
        return Ok(values);
    }
}