using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Command.EditUserProfile;
using Ryder.Application.User.Query.GetCurrentUser;
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

        [HttpPut("UpdateUserProfile/{id}")]
        public async Task<IActionResult> UpdateUaserProfile(string userId, [FromBody] ProfileModel profileUpdate)
        {
            return await Initiate(() => Mediator.Send(new EditUserProfileComand(userId, profileUpdate)));
        }
    }
}
