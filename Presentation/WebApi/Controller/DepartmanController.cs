using Application.Features.Queries.DepartmanQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class DepartmanController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmanController(IMediator mediator)
    {
         _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var values = await _mediator.Send(new GetDepartmanQuery());
        return Ok(values);  
    }
   
    
}