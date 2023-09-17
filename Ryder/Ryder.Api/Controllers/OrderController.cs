using Microsoft.AspNetCore.Mvc;
using Ryder.Application.Orders.Command.PlaceOrder;
using Ryder.Application.Orders.Query.GetAllOrder;
using Ryder.Application.Orders.Query.GetOderById;

namespace Ryder.Api.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand placeOrder)
        {
            return await Initiate(() => Mediator.Send(placeOrder));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            return await Initiate(() => Mediator.Send(new GetAllOrderQuery()));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            return await Initiate(() => Mediator.Send(new GetOrderByIdQuery { OrderId = orderId }));
        }
    }
}
