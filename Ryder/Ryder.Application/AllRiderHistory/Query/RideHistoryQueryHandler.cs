using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.AllRiderHistory.Query
{
    public class RideHistoryQueryHandler : IRequestHandler<RideHistoryQuery, IResult<IList<Order>>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public RideHistoryQueryHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task <IResult<IList<Order>>> Handle(RideHistoryQuery request, CancellationToken cancellationToken)
        {
            var rideHistory = await _context.Orders
            .Where(r => r.RiderId == request.RiderId)
            .ToListAsync();

            if (rideHistory == null || !rideHistory.Any())
            {
                return await Result<List<Order>>.FailAsync();
            }

            var rideHistoryDTOs = _mapper.Map<Result<List<Order>>>(rideHistory);
            return rideHistoryDTOs;
        }
    }
}
