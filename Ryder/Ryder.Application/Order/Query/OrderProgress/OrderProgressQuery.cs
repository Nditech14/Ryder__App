using AspNetCoreHero.Results;
using MediatR;
using Ryder.Domain.Entities; // Assuming OrderStatus is defined in this namespace
using Ryder.Domain.Enums;
using System;
using System.Threading;

namespace Ryder.Application.Order.Query.OrderProgress
{
    public class OrderProgressQuery : IRequest<IResult<OrderProgressResponse>>
    {
        public Guid OrderId { get; set; }
        public Guid AppUserId { get; set; }

    }
}
