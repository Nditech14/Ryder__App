using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.order.Query.OrderProgress
{
     public class OrderProgressResponse
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public  Address PickUpLocation { get; set; }
        public Address DropOffLocation { get;}
       
    }
}
