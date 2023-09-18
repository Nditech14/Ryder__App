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

namespace Ryder.Application.Orders.Query.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IResult<List<Order>>>
    {
        private readonly ApplicationContext _context;
        public GetAllOrderQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IResult<List<Order>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken);
            return Result<List<Order>>.Success(orders);
        }
    }
}
