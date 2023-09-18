using Microsoft.AspNetCore.Mvc;
using Ryder.Application.Orders.Command.PlaceOrder;
using Ryder.Application.Orders.Query.GetAllOrder;
using Ryder.Application.Orders.Query.GetOderById;
using Ryder.Application.order.Query.AcceptOrder;
using Ryder.Application.order.Query.EndRide;
using Ryder.Application.order.Query.OrderProgress;
using Microsoft.Extensions.Logging; // Import the logging library.

namespace Ryder.Api.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand placeOrder)
        private readonly ILogger<OrderController> _logger; // Inject the logger.

        public OrderController(ILogger<OrderController> logger)
        {
            return await Initiate(() => Mediator.Send(placeOrder));
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

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        [HttpPost("progress")]
        public async Task<IActionResult> RequestProgress([FromBody] OrderProgressCommand command)
        {
            return await Initiate(() => Mediator.Send(new GetAllOrderQuery()));
            // Log an information message when the RequestProgress action is invoked.
            _logger.LogInformation("RequestProgress action invoked.");

            return await Initiate(() => Mediator.Send(command));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        [HttpPost("end")]
        public async Task<IActionResult> EndRide([FromBody] EndRideCommand command)
        {
            return await Initiate(() => Mediator.Send(new GetOrderByIdQuery { OrderId = orderId }));
            // Log an information message when the EndRide action is invoked.
            _logger.LogInformation("EndRide action invoked.");

            return await Initiate(() => Mediator.Send(command));
        }
    }
}
