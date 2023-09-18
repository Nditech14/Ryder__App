using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryder.Application.SignUp.Command.CreateRider;
using Ryder.Application.SignUp.Command.CreateUser;
using Ryder.Application.User.Query.GetCurrentUser;

namespace Ryder.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        [AllowAnonymous]
        [HttpPost("SignUpUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            return await Initiate(() => Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("SignUpRider")]
        public async Task<IActionResult> CreateRider(CreateRiderCommand command)
        {
            return await Initiate(() => Mediator.Send(command));
        }
    }
}
