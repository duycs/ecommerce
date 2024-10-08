using ECommerce.Shared.Enum;
using ECommerce.Shared.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synchronize.Domain.OrderAggregate
{
    [Table("orders", Schema = "order")]
    public class Order : DateModiferTrackingEntity
    {
        public int Status { get; private set; }
        public OrderStatus OrderStatus
        {
            get { return Enumeration.FromValue<OrderStatus>(Status); }
            set { Status = value.Id; }
        }
        public string StaffPhone { get; private set; }
        public string StaffName { get; private set; }
        public string SaasCode { get; private set; }
        public Guid CustomerId { get; private set; }
        protected Order() { }

        public bool UpdateStatus(OrderStatus status)
        {
            if (status != null)
            {
                if (OrderStatus.Equals(OrderStatus.Cancel) || OrderStatus.Equals(OrderStatus.Completed) || status.Equals(OrderStatus))
                {
                    return false;
                }
                OrderStatus = status;
                return true;
            }
            return false;
        }

        public bool UpdateCode(string code)
        {
            if (SaasCode != code)
            {
                SaasCode = code;
                return true;
            }
            return false;
        }

        public bool UpdateStaff(string staffName, string staffPhone)
        {
            if (StaffPhone != staffPhone || StaffName != staffName)
            {
                StaffPhone = staffPhone;
                StaffName = staffName;
                return true;
            }
            return false;
        }
    }
}
