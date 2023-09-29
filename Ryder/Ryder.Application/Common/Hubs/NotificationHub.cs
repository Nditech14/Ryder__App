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

namespace Ryder.Application.Common.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {

		
		public async Task NotifyRidersOfIncomingRequest(List<string> riderId)
		{
			await Clients.Users(riderId).SendAsync("IncomingRequest", "You have an incoming request.");
			
		}

	
		public async Task NotifyUserOfRequestAccepted(string userId)
		{
			await Clients.User(userId).SendAsync("RequestAccepted", "Your request has been accepted.");
		}


		public async Task NotifyUserAndRiderOfOrderCompleted(string userId, string riderId)
		{
			await Clients.Users(userId, riderId).SendAsync("OrderCompleted", "order has been completed.");
			
		}


	}
}
