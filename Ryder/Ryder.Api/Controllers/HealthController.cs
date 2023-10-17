using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ryder.Api.Controllers
{
    [AllowAnonymous]
    public class HealthController : ApiController
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpGet("error/500")]
        public IActionResult GetThrow500()
        {
            throw new Exception();
        }

        [HttpGet("error/BadRequest400")]
        public IActionResult GetThrowBadRequest40()
        {
            return new BadRequestResult();
        }

        [HttpGet("logs")]
        public IActionResult Logs()
        {
            var aaa = $"/temp/nlog-all-{DateTime.Now:yyyy-MM-dd}";
            //var rrr = "\"C:\\temp\\nlog-all-2023-10-17.log\"";
            var text = System.IO.File.ReadAllText($"/temp/nlog-all-{DateTime.Now:yyyy-MM-dd}.log");
            return Content(text, "text/plain");
        }

        [HttpPut("clearlogs")]
        public IActionResult ClearLogs()
        {
            System.IO.File.WriteAllText($"/temp/nlog-all-{DateTime.Now:yyyy-MM-dd}.log",
                string.Empty);
            return Ok("Success");
        }
    }
}