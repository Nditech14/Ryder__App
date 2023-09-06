using Ryder.Domain.Common;
using Ryder.Domain.Enums;

namespace Ryder.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Address PickUpLocation { get; set; }
        public Address DropOffLocation { get; set; }
        public string PickUpPhoneNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}