using AspNetCoreHero.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ryder.Application.User.Command.ForgetPassword;
using Ryder.Application.User.Command.ResetPassword;
using System.Threading.Tasks;

namespace Ryder.Api.Controllers
{
    [Route("api/v1/auth")]
    public class AuthController : ApiController
    {
        [HttpPost("forget-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand request)
        {
            return await Initiate(async () => await Mediator.Send(request));
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand request)
        {
            return await Initiate(async () => await Mediator.Send(request));
        }
    }
}
