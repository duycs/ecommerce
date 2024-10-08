using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Shared.Enum;
using ECommerce.Shared.Exceptions;
using Order.Domain.DomainEvents;
using ECommerce.Shared.SeedWork;
using ECommerce.Shared.Extensions;

namespace Order.Domain.AggregateModels.OrderAggregate
{
    public class CustomerOrder : DateModiferTrackingEntity, IAggregateRoot
    {
        public uint OrderNumber { get; private set; }
        public string OrderCode => $"{OrderNumber.ToString("D8")}{Convert.ToBase64String(Id.ToByteArray())}";
        public int Status { get; private set; }
        public OrderStatus OrderStatus
        {
            get { return Enumeration.FromValue<OrderStatus>(Status); }
            set { Status = value.Id; }
        }
        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerPhone { get; private set; }
        public string CustomerAddress { get; private set; }
        public Guid? ProvinceId { get; private set; }
        public string ProvinceName { get; private set; }
        public Guid? DistrictId { get; private set; }
        public string DistrictName { get; private set; }
        public Guid? WardId { get; private set; }
        public string WardName { get; private set; }
        public decimal DiscountPrice { get; private set; }
        public string Note { get; private set; }
        public DateTime DateTimeOrder { get; private set; }
        public string StaffPhone { get; private set; }
        public string StaffName { get; private set; }
        public string SaasCode { get; private set; }
        public string PaymentMethod { get; private set; }
        public string CarriageNumber { get; private set; }
        public virtual ICollection<OrderDetail> Details { get; private set; }
        public virtual decimal TotalPrice => Details.Sum(a => a.Price * a.Quantity);
        public virtual decimal TotalNetPrice => Details.Sum(a => a.NetPrice * a.Quantity) - DiscountPrice;
        protected CustomerOrder() { }

        public CustomerOrder(Guid id,
            Guid customerId,
            string customerName,
            string customerPhone,
            string customerAddress,
            Guid? provinceId,
            string provinceName,
            Guid? districtId,
            string districtName,
            Guid? wardId,
            string wardName,
            decimal discountPrice,
            string note,
            DateTime dateTimeOrder)
        {
            Id = id;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
            ProvinceId = provinceId;
            ProvinceName = provinceName;
            DistrictId = districtId;
            DistrictName = districtName;
            WardId = wardId;
            WardName = wardName;
            DiscountPrice = discountPrice;
            Note = note;
            DateTimeOrder = dateTimeOrder;
            Status = OrderStatus.Pending.Id;
        }

        public void AddDetails(IEnumerable<OrderDetail> details)
        {
            Details = details.ToList();
        }

        public void Cancel()
        {
            if (Status != OrderStatus.Pending.Id)
                throw new BusinessRuleException(ECommerceBusinessRule.OrderApproved);

            AddDomainEvent(new OrderStatusChangedDomainEvent(Id, SaasCode, OrderStatus, OrderStatus.Cancel, CustomerId));
            Status = OrderStatus.Cancel.Id;
        }

        public void ChangeInfo(
            string customerName,
            string customerPhone,
            string customerAddress,
            Guid? provinceId,
            string provinceName,
            Guid? districtId,
            string districtName,
            Guid? wardId,
            string wardName,
            string note)
        {
            if (Status != OrderStatus.Pending.Id)
                throw new BusinessRuleException(ECommerceBusinessRule.OrderApproved);

            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
            ProvinceId = provinceId;
            ProvinceName = provinceName;
            DistrictId = districtId;
            DistrictName = districtName;
            WardId = wardId;
            WardName = wardName;
            Note = note;

        }
    }
}
