using ECommerce.Shared.Enum;
using System.Collections.Generic;

namespace Order.Application.Models.Orders
{
    public class OrderHistoriesDto
    {
        public OrderHistoriesDto(OrderStatus orderStatus, int quantity)
        {
            Id = orderStatus.Id;
            Name = orderStatus.Name;
            Quantity = quantity;
        }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } 
    }
}
