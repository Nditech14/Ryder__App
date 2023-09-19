using MediatR;
using Ryder.Application.User.Query.ResendConfirmationEmail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ryder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResendConfirmationEmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResendConfirmationEmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<ResendConfirmationEmailController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResendConfirmationEmailCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}

