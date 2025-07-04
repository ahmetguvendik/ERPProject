using Application.Features.Queries.PurchaseOfferQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOfferController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchaseOfferController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        var values = await _mediator.Send(new GetPurchaseOfferQuery(id));
        if (values == null)
        {
            return NotFound();
        }
        return Ok(values);
    }
}