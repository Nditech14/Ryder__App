using AspNetCoreHero.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Orders.Query.GetOderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, IResult<Order>>
    {
        private readonly ApplicationContext _context;
        public GetOrderByIdQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IResult<Order>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == query.OrderId, cancellationToken);
            if (order == null)
            {
                return null;
            }

            return Result<Order>.Success(order);

        }
    }
}
