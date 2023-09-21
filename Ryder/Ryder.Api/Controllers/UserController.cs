using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Query.GetCurrentUser;
using Ryder.Application.User.Query.GetUserProfile;
using System.Security.Claims;

namespace Ryder.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return await Initiate(() => Mediator.Send(new GetCurrentUserCommand()));
        }

        [HttpGet("GetUserProfile")]
        public async Task<IActionResult> GetUserProfileAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);    
            return await Initiate(() => Mediator.Send(new GetUserProfileQuery(userId)));
        }
    }
}
