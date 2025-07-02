using Application.Features.Commands;
using Application.Features.Results.AppUserResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var value = await _mediator.Send(command);
        if (value.Id == null)
        {
            return BadRequest();
        }
        return Ok(value);    
    }
}