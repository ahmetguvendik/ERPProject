using Application.Features.Queries.AppUserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var value = await _mediator.Send(new GetUserByIdQuery(userId));
        return Ok(value);
    }
}