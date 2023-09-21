using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ryder.Application.Hubs
{
	[Authorize]
	public class OrderStatusHub : Hub
	{

		public async Task JoinRidersGroup()
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, "Riders");
		}


		public async Task NotifyRidersAboutOrderRequest(Order order)
		{
			// Broadcast the order request to all connected riders
			await Clients.Group("Riders").SendAsync("OrderRequestReceived", order);
		}



		public async Task NotifyRequestAccepted(Guid orderId)
		{
			// Notify the rider who accepted the request
			await Clients.Caller.SendAsync("RequestAccepted", orderId);

			// Notify the user
			await Clients.User(orderId.ToString()).SendAsync("RequestAccepted", orderId);
		}



		public async Task NotifyOrderCompleted(Guid orderId)
		{
			// Notify the rider
			await Clients.Caller.SendAsync("OrderCompleted", orderId);

			// Notify the user
			await Clients.User(orderId.ToString()).SendAsync("OrderCompleted", orderId);
		}


	}
}
