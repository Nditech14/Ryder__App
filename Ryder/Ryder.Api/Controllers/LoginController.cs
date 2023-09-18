//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Query.Login;
using System.Runtime.CompilerServices;

namespace Ryder.Api.Controllers
{
    [Route("APi/Login")]
    [ApiController]
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(string email, string password)
        {
            return await Initiate(() => Mediator.Send(new LoginCommand { Email = email, Password = password }));
        }
    }
}
