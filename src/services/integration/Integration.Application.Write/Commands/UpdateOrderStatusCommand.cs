using ECommerce.Shared.Enum;
using ECommerce.Shared.SeedWork;
using MediatR;

namespace Integration.Application.Write.Commands
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public uint OrderId { get; set; }
        [AllowedOrderStatus(ErrorMessage = "Status is not allowed to update")]
        public int StatusCode { get; set; }
        public OrderStatus OrderStatus => Enumeration.FromValue<OrderStatus>(StatusCode);
    }
}
