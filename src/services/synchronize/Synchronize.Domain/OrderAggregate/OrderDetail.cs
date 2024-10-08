using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synchronize.Domain.OrderAggregate
{
    [Table("order_details", Schema = "order")]
    public class OrderDetail : DateModiferTrackingEntity
    {
        public Guid OrderId { get; private set; }
        public uint Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal DiscountPrice { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductSku { get; private set; }
        public string ProductName { get; private set; }
        public Guid ProductChildId { get; private set; }
        public string ProductChildName { get; private set; }
        public string ProductChildSku { get; private set; }
        public string ProductImage { get; set; }
        public Guid? BrandId { get; private set; }
        public string BrandName { get; private set; }
        public Guid ProductCategoryId { get; private set; }
        public string ProductCategoryName { get; private set; }
        public Guid ShopId { get; private set; }
        public string ShopName { get; private set; }
        public IEnumerable<OrderProductAttributeValue> AttributeValues { get; private set; }

        protected OrderDetail()
        {
        }

        public OrderDetail(Guid orderId,
            uint quantity,
            decimal price,
            decimal discountPrice,
            Guid productId,
            string productSku,
            string productName,
            Guid productChildId,
            string productChildName,
            string productChildSku,
            Guid? brandId,
            string brandName,
            Guid productCategoryId,
            string productCategoryName,
            Guid shopId,
            string shopName)
        {
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
            DiscountPrice = discountPrice;
            ProductId = productId;
            ProductSku = productSku;
            ProductName = productName;
            ProductChildId = productChildId;
            ProductChildName = productChildName;
            ProductChildSku = productChildSku;
            BrandId = brandId;
            BrandName = brandName;
            ProductCategoryId = productCategoryId;
            ProductCategoryName = productCategoryName;
            ShopId = shopId;
            ShopName = shopName;
        }

        public void AddAttributeValues(IEnumerable<OrderProductAttributeValue> values)
        {
            AttributeValues = values;
        }

        public bool UpdateQuantity(uint quantity)
        {
            if (Quantity != quantity)
            {
                Quantity = quantity;
                return true;
            }
            return false;
        }
    }
}
