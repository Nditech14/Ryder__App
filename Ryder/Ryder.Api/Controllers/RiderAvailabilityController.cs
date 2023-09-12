using Microsoft.AspNetCore.Mvc;
using Ryder.Api.Controllers;
using Ryder.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RiderAvailabilityController : ApiController
{
    private readonly IRiderService _riderService;

    public RiderAvailabilityController(IRiderService riderService)
    {
        _riderService = riderService;
    }

    [HttpPost]
    [Route("api/riders/{riderId}/availability")]
    public async Task<IActionResult> SetRiderAvailability(string riderId, bool isAvailable)
    {
        try
        {
            var success = await _riderService.SetRiderAvailabilityAsync(riderId, isAvailable);

            if (success)
            {
                return Ok(); // Availability updated successfully
            }
            else
            {
                return NotFound(); // Rider not found
            }
        }
        catch (Exception ex)
        {
            return BadRequest (ex); // Handle exceptions
        }
    }

    [HttpGet]
    [Route("api/riders/available")]
    public IActionResult GetAvailableRiders()
    {
        try
        {
            var availableRiders = _riderService.GetAvailableRiders();
            return Ok(availableRiders);
        }
        catch (Exception ex)
        {
            return BadRequest (ex); // Handle exceptions
        }
    }
}
