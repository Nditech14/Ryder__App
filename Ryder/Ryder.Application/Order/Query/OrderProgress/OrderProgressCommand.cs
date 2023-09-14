using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using Ryder.Application.User.Query.GetCurrentUser;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Order.Query.OrderProgress
{
    public class OrderProgressCommand : IRequest<IResult<OrderProgressResponse>>
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public Address PickUpLocation { get; set; }
        public Address DropOffLocation { get; }
       
        // Represents the new status for the order's progress
    }

    public class OrderProgressCommandValidator : AbstractValidator<OrderProgressCommand>
    {
        public OrderProgressCommandValidator()
        {
        }
    }
}
