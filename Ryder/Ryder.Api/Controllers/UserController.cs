using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Query.GetCurrentUser;
using Ryder.Application.User.Query.Login;
using Ryder.Application.User.Query.ResendConfirmationEmail;

namespace Ryder.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return await Initiate(() => Mediator.Send(new GetCurrentUserCommand()));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            return await Initiate<LoginResponse>(() => Mediator.Send(request));
        }

        [HttpPost("ResendConfirmationEmail")]
        public async Task<IActionResult> ResendConfirmationEmail()
        {
            var response = await Mediator.Send<ResendConfirmationEmailResponse>(new ResendConfirmationEmailCommand());

            if (response != null && response.IsSuccess)
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