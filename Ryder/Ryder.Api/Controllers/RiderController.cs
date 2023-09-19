using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryder.Api.Controllers;
using Ryder.Application.RiderAvailability.Command;
using Ryder.Application.RiderAvailability.Query;

public class RiderController : ApiController
{
    [HttpPost("update-availability/{id}")]
    public async Task<IActionResult> UpdateRiderAvailability(Guid id, UpdateRiderAvailabilityCommand command)
    {
        command.RiderId = id;
        return await Initiate(() => Mediator.Send(command));
    }

    [HttpGet("get-availability/{id}")]
    public async Task<IActionResult> GetRiderAvailability(Guid id)
    {
        return await Initiate(() => Mediator.Send(new GetRiderAvailabilityQuery { RiderId = id }));
    }
}