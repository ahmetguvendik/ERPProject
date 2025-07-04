using Application.Features.Queries.PurchaseQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class PurchaseItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchaseItemsController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetPurchaseByIdQuery(id));
        return Ok(value);
    }
}