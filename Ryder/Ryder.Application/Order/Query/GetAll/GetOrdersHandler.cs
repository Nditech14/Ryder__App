using AspNetCoreHero.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;
using Ryder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Order.Query.GetAll
{
    public class GetOrdersHandler : IRequestHandler<GetOrders, IResult<List<GetOrdersResponse>>>
    {
        private readonly ApplicationContext _context;

        public GetOrdersHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IResult<List<GetOrdersResponse>>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .Where(o => o.StartTime >= request.Created && o.Status == OrderStatus.OrderPlaced)
                .ToListAsync(cancellationToken);

            var orderResponses = orders.Select(order => new GetOrdersResponse
            {
                OrderId = order.Id,
                PickUpLocationAddressDescription = order.PickUpLocation.AddressDescription,
                DropOffLocationAddressDescription = order.DropOffLocation.AddressDescription,
                PackageDescription = order.PackageDescription,
                Amount = order.Amount,
                Status = order.Status
            }).ToList();

            return Result<List<GetOrdersResponse>>.Success(orderResponses);
        }
    }
}
