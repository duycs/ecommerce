using ECommerce.Shared.Enum;
using ECommerce.Shared.SeedWork;
using System;

namespace Order.Application.Models.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalMoneyTemp { get; set; }
        public decimal DiscountPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string Note { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public int Status { get; set; }
        public string CarriageNumber { get; set; }
        public OrderStatus StatusName => Enumeration.FromValue<OrderStatus>(Status);
    }
}
