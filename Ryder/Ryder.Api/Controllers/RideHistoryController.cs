using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryder.Application.AllRiderHistory.Query;
using Ryder.Domain.Entities;

namespace Ryder.Api.Controllers
{
    [Route("api/ridehistorybyid")]
    [ApiController]
    public class RideHistoryController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("ride-history-by-id/{riderId}")]
        public async Task<IActionResult> GetRideHistoryById(Guid riderId)
        {
            
            return await Initiate(() => Mediator.Send(new RideHistoryQuery { RiderId = riderId }));
        }
    }
}
