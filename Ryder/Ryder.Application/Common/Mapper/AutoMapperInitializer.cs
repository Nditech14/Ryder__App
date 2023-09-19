using AutoMapper;
using Ryder.Application.AllRiderHistory.Query;
using Ryder.Domain.Entities;

namespace Ryder.Application.Common.Mapper
{
    public class AutoMapperInitializer : Profile
    {
        public AutoMapperInitializer()
        {
            CreateMap<Address, Location>();
            CreateMap<Order, GetOrderResponse>();
        }
    }
}