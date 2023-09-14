using Microsoft.AspNetCore.Mvc;
using Ryder.Application.Order.Query.AcceptOrder;
using Ryder.Application.Order.Query.EndRide;
using Ryder.Application.Order.Query.OrderProgress;
using Microsoft.Extensions.Logging; // Import the logging library.

namespace Ryder.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly ILogger<OrderController> _logger; // Inject the logger.

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;

            // Log an information message when the controller is initialized.
            _logger.LogInformation("OrderController initialized.");
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptOrder([FromBody] AcceptOrderCommand command)
        {
            // Log an information message when the AcceptOrder action is invoked.
            _logger.LogInformation("AcceptOrder action invoked.");

            return await Initiate(() => Mediator.Send(command));
        }

        [HttpPost("progress")]
        public async Task<IActionResult> RequestProgress([FromBody] OrderProgressCommand command)
        {
            // Log an information message when the RequestProgress action is invoked.
            _logger.LogInformation("RequestProgress action invoked.");

            return await Initiate(() => Mediator.Send(command));
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndRide([FromBody] EndRideCommand command)
        {
            // Log an information message when the EndRide action is invoked.
            _logger.LogInformation("EndRide action invoked.");

            return await Initiate(() => Mediator.Send(command));
        }
    }
}
