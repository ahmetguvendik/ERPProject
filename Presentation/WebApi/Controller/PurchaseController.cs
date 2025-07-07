using Application.Features.Commands.PurchaseCommands;
using Application.Features.Commands.RequestCommands;
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
    
    [HttpPost("CreatePurchaseOffer")]
    public async Task<IActionResult> CreatePurchaseOffer(CreatePurchaseOfferCommand createPurchaseOfferCommand)
    {
        await _mediator.Send(createPurchaseOfferCommand);
        return Ok("Teklif Oluşturuldu");        
    }


    [HttpGet]
    public async Task<IActionResult>  GetPurchaseByUserId(string userId)
    {
        var values = await _mediator.Send(new GetPurchaseByUserIdQuery(userId));
        return Ok(values);
    }
    
    [HttpGet("GetPurchaseByManagerId")]
    public async Task<IActionResult>  GetPurchaseByManagerId(string managerId)
    {
        var values = await _mediator.Send(new GetPurchaseByManagerIdQuery(managerId));
        return Ok(values);
    }
    [HttpGet("GetPurchaseByApprovedManager")]
    public async Task<IActionResult>  GetPurchaseByApprovedManager()
    {
        var values = await _mediator.Send(new GetPurchaseByApprovedManagerQuery());
        return Ok(values);
    }
    [HttpGet("GetSearchingPurchase")]
    public async Task<IActionResult>  GetSearchingPurchase()
    {
        var values = await _mediator.Send(new GetSearchingPurchaseQuery());
        return Ok(values);
    }
    
    [HttpPut("[action]")]   
    public async Task<IActionResult> UpdateApprovedPurchase([FromBody] UpdateApprovedPurchaseCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }
    
    [HttpPut("[action]")]   
    public async Task<IActionResult> UpdateRejectPurchase([FromBody] UpdateRejectPurchaseCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");   
    }
    
    [HttpPut("[action]")]   
    public async Task<IActionResult> UpdateBackToManagerPurchase([FromBody] UpdateBackToManagerPuchaseCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");   
    }
    
    [HttpPut("UpdatePurchase")]
    public async Task<IActionResult> UpdatePurchase([FromBody] UpdatePurchaseCommand command)
    {
        await _mediator.Send(command);
        return Ok("Güncellendi");   
    }

    [HttpPut("SearchingPurchase")]
    public async Task<IActionResult> SearchingPurchase([FromBody] UpdateSearchingPurchaseCommand command)
    {
        await _mediator.Send(command);
        return Ok("Güncellendi");       
    }
    
}