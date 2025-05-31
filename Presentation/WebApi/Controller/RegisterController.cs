using Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IMediator  _mediator;

    public RegisterController(IMediator mediator)   
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");   
    }
}
