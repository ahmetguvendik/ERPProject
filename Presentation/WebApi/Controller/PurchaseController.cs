using Application.Features.Commands.PurchaseCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchaseController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Get(CreatePurchaseCommand createPurchaseCommand)
    {
        await _mediator.Send(createPurchaseCommand);
        return Ok("Talep Oluşturuldu");
    }
}