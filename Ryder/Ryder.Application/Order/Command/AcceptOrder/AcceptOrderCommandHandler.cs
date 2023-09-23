using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using AspNetCoreHero.Results;
using Ryder.Domain.Context;
using Microsoft.Extensions.Logging; // Import the logging library.
using Ryder.Application.Common.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Ryder.Application.Order.Command.AcceptOrder
{
    public class AcceptOrderCommandHandler : IRequestHandler<AcceptOrderCommand, IResult<AcceptOrderResponse>>
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<AcceptOrderCommandHandler> _logger; // Inject the logger.
        public readonly NotificationHub _notificationHub;

		public AcceptOrderCommandHandler(ApplicationContext context, ILogger<AcceptOrderCommandHandler> logger, NotificationHub notificationHub)
		{
			_context = context;
			_logger = logger;
			_notificationHub = notificationHub;
		}

		public async Task<IResult<AcceptOrderResponse>> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the order by its unique identifier (orderId) from your context
            var order = await _context.Orders.FirstOrDefaultAsync(row=> row.UserId ==  request.UserId && row.Id == request.OrderId);

            if (order == null)
            {
                // Log an information message when the order is not found.
                _logger.LogInformation($"Order with ID {request.OrderId} not found.");

                // Handle the case where the order is not found
                return Result<AcceptOrderResponse>.Fail($"Order with ID {request.OrderId} not found.");
            }

            if (order.Status != OrderStatus.InProgress)
            {
                // Log an information message when the order cannot be accepted.
                _logger.LogInformation($"Order with ID {request.OrderId} cannot be accepted.");

                // Handle the case where the order cannot be accepted 
                return Result<AcceptOrderResponse>.Fail($"Order with ID {request.OrderId} cannot be accepted.");
            }

            // Assign the rider ID to the order and update its status to "Accepted"
            order.RiderId = request.RiderId;
            order.Status = OrderStatus.Accepted;
            order.UserId = request.UserId;

            // Save the updated order to your data source (e.g., database)
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            // Log an information message when the order is successfully accepted.
            _logger.LogInformation($"Order with ID {request.OrderId} accepted.");


            /* >>>>>>>>>>>>>>>> By Ajibade Victor >>>>>>>>>>>>>>>>>>>>>>>*/

			await _notificationHub.NotifyUserOfRequestAccepted(order.UserId.ToString());

			/* >>>>>>>>>>>>>>>> By Ajibade Victor >>>>>>>>>>>>>>>>>>>>>>>*/

			// Handle the successful update
			return Result<AcceptOrderResponse>.Success($"Order with ID {request.OrderId} accepted.");
        }


    }
}
