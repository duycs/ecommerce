using AutoMapper;
using ECommerce.Shared.Extensions;
using Integration.Events.OrderEvents;
using Order.Domain.AggregateModels.OrderAggregate;
using System.Collections.Generic;

namespace Order.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDetail, OrderDetailCancelledIntegratedEvent>();
            CreateMap<CustomerOrder, OrderCancelledIntegratedEvent>()
                .ForMember(a => a.OrderId, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Details, b => b.MapFrom(c => c.Details.To<IEnumerable<OrderDetailCancelledIntegratedEvent>>()));
        }
    }
}
