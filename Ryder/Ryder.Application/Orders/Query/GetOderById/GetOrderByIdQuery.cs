using AspNetCoreHero.Results;
using MediatR;
using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Orders.Query.GetOderById
{
    public class GetOrderByIdQuery : IRequest<IResult<Order>>
    {
        public Guid OrderId { get; set; }
    }
}
