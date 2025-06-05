using Application.Features.Commands.RequestCommands;
using Application.Features.Queries.LeaveRequestQueries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[action]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> LeaveRequest(CreateRequestCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok(new { message = "İzin isteği başarıyla gönderildi." });
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Sunucu hatası oluştu." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> LeaveRequestByEmployeeId(string employeeId)
    {
        var values = await _mediator.Send(new GetLeaveRequestByEmployeeIdQuery(employeeId));   
        return Ok(values);
    }


    [HttpGet ("[action]/{managerId}")]          
    public async Task<IActionResult> LeaveRequestByManagerId(string managerId)  
    {
        var values = await _mediator.Send(new GetLeaveRequestByManagerIdQuery(managerId));      
        return Ok(values);  
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLeaveRequest([FromBody]UpdateLeaveRequestCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }
    
    
    [HttpPut("[action]")]   
    public async Task<IActionResult> UpdateRejectLeaveRequest([FromBody] UpdateRejectLeaveRequestCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }
}