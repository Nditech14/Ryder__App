using AspNetCoreHero.Results;
using MediatR;
using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.AllRiderHistory.Query
{
    public class RideHistoryQuery : IRequest<IResult<IList<GetOrderResponse>>>
    {
        public Guid RiderId { get; set; }
    }
}
