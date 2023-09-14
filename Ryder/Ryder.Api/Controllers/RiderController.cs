using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ryder.Api.Controllers;
using Ryder.Application.RiderAvailability.Command;
using Ryder.Application.RiderAvailability.Query;

[ApiController]
[Route("api/riders")]
public class RidersController : ApiController
{
    private readonly IMediator _mediator;

    public RidersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("update-availability/{id}")]
    public async Task<IActionResult> UpdateRiderAvailability(Guid id, [FromBody] UpdateRiderAvailabilityCommand command)
    {

        return await Initiate(() => Mediator.Send(new UpdateRiderAvailabilityCommand { RiderId = id }));
      
       
    }

    [HttpGet("get-availability/{id}")]
    public async Task<IActionResult> GetRiderAvailability(Guid id)
    {
        var query = new GetRiderAvailabilityQuery { RiderId = id };
        return await Initiate(() => Mediator.Send(query));

    }

    
}
