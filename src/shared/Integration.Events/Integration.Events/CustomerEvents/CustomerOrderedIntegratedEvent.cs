using EventBus.Events;
using System;
using System.Collections.Generic;

namespace Integration.Events.CustomerEvents
{
    public class CustomerOrderedIntegratedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public Guid? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public Guid? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid? WardId { get; set; }
        public string WardName { get; set; }
        public uint DiscountPrice { get; set; }
        public string Note { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public IEnumerable<OrderCreatedDetailIntegratedEvent> Details { get; set; }
    }

    public class OrderCreatedDetailIntegratedEvent
    {
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public Guid ProductId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Guid ProductChildId { get; set; }
        public string ProductChildName { get; set; }
        public string ProductChildSku { get; set; }
        public Guid? BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public IEnumerable<OrderCreatedProductAttributeValue> AttributeValues { get; set; }
    }

    public class OrderCreatedProductAttributeValue
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AttributeName { get; set; }
        public int Priority { get; set; }
    }
}
