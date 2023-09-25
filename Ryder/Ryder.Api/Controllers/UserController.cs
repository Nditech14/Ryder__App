using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet("GetUserProfile/{id}")]
        public async Task<IActionResult> GetUserProfileAsync(string id)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = "7cd2e636-df08-4e3c-95e6-a337808037bb";
            return await Initiate(() => Mediator.Send(new GetUserProfileQuery(id)));
        }
    }
}
