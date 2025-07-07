using Application.Features.Commands.PurchaseCommands;
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

    [HttpPut]
    public async Task<IActionResult> UpdateOffer(UpdateApprovedOfferCommand  command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok("Teklif başarıyla onaylandı.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}