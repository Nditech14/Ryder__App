using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.Order.Query.GetAll
{
    public class GetOrders : IRequest<IResult<GetOrdersResponse>>
    {
        public DateTime Created { get; set; } = new DateTime(2023, 10, 22);
    }
}
