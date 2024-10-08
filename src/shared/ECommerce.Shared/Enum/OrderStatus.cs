using ECommerce.Shared.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ECommerce.Shared.Enum
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Pending = new OrderStatus(1, "Chờ xử lý");
        public static OrderStatus Executing = new OrderStatus(2, "Đang xử lý");
        public static OrderStatus Shipping = new OrderStatus(3, "Đang vận chuyển");
        public static OrderStatus Completed = new OrderStatus(4, "Đã giao");
        public static OrderStatus Cancel = new OrderStatus(5, "Đã hủy");

        public static int[] AllowedStatusUpdateIds = new int[] { Pending.Id, Shipping.Id };

        public OrderStatus() : base() { }
        public OrderStatus(int id, string name) : base(id, name) { }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AllowedOrderStatus : ValidationAttribute
    {
        public AllowedOrderStatus() : base()
        {
        }

        public override bool IsValid(object value)
        {
            var statusCode = (int)value;
            return OrderStatus.AllowedStatusUpdateIds.Contains(statusCode);
        }
    }
}