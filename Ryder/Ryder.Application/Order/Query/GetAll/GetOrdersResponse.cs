using Ryder.Domain.Enums;

namespace Ryder.Application.Order.Query.GetAll
{
    public class GetOrdersResponse
    {
        public Guid OrderId { get; set; }
        public string PickUpLocationAddressDescription { get; set; }
        public string DropOffLocationAddressDescription { get; set; }
        public string PackageDescription { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
    }
}