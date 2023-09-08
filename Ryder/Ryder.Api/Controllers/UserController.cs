using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Query.GetCurrentUser;

namespace Ryder.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser(GetCurrentUserCommand command)
        {
            return await Initiate(() => Mediator.Send(command));
        }
    }
}