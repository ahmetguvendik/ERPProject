using Application.Features.Commands.PurchaseCommands;
using Application.Features.Queries.PurchaseQueries;
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
    public async Task<IActionResult> CreatePurchase(CreatePurchaseCommand createPurchaseCommand)
    {
        await _mediator.Send(createPurchaseCommand);
        return Ok("Talep Oluşturuldu");
    }

    [HttpGet]
    public async Task<IActionResult>  GetPurchaseByUserId(string userId)
    {
        var values = await _mediator.Send(new GetPurchaseByUserIdQuery(userId));
        return Ok(values);
    }
    
}