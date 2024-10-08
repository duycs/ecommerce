using ECommerce.Shared.Enum;
using ECommerce.Shared.SeedWork;
using Integration.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Integration.Domain.OrderAggregateModels
{
    public class Order : DateTrackingEntity, IAggregateRoot
    {
        public int Status { get; private set; }
        public string StaffPhone { get; private set; }
        public string StaffName { get; private set; }
        public string SaasCode { get; private set; }
        public uint OrderNumber { get; private set; }
        public string Note { get; private set; }
        public Guid CustomerId { get; private set; }
        public virtual IList<OrderDetail> Details { get; private set; }

        [NotMapped]
        public OrderStatus OrderStatus
        {
            get { return Enumeration.FromValue<OrderStatus>(Status); }
            set { Status = value.Id; }
        }

        protected Order() { }

        public void Confirm(string staffName = "", string staffPhone = "")
        {
            if (OrderStatus == OrderStatus.Pending)
            {
                OrderStatus = OrderStatus.Executing;
                StaffName = staffName;
                StaffPhone = staffPhone;
                AddDomainEvent(new OrderStatusChangedDomainEvent(Id, SaasCode, OrderStatus.Pending, OrderStatus, CustomerId));
            }
        }

        public void Cancel()
        {
            if (OrderStatus != OrderStatus.Completed)
            {
                AddDomainEvent(new OrderStatusChangedDomainEvent(Id, SaasCode, OrderStatus, OrderStatus.Cancel, CustomerId));
                OrderStatus = OrderStatus.Cancel;
            }
        }

        public void UpdateStatus(OrderStatus status)
        {
            if (OrderStatus != OrderStatus.Completed && OrderStatus != OrderStatus.Cancel)
            {
                AddDomainEvent(new OrderStatusChangedDomainEvent(Id, SaasCode, OrderStatus, status, CustomerId));
                OrderStatus = status;
            }
        }

        public void SaasCreated(string orderCode, uint orderNumber)
        {
            SaasCode = orderCode;
            OrderNumber = orderNumber;
        }

        public void AddQuantity(Guid productChildId, uint quantity)
        {
            var detail = Details.FirstOrDefault(a => a.ProductChildId == productChildId);
            if (detail != null)
            {
                detail.AddQuantity(quantity);
            }
        }

        public void AddDetail(OrderDetail orderDetail)
        {
            Details ??= new List<OrderDetail>();
            if (Details.Any(a => a.ProductChildId == orderDetail.ProductChildId))
            {
                return;
            }
            Details.Add(orderDetail);
        }

        public void RemoveQuantity(Guid productChildId, uint quantity)
        {
            var detail = Details.FirstOrDefault(a => a.ProductChildId == productChildId);
            if (detail != null)
            {
                detail.RemoveQuantity(quantity);
            }
        }

        public void RemoveDetail(Guid productChildId)
        {
            Details ??= new List<OrderDetail>();
            Details = Details.Where(a => a.ProductChildId != productChildId).ToList();
        }

        public uint? GetDetailQuantity(Guid productChildId)
        {
            var detail = Details.FirstOrDefault(a => a.ProductChildId == productChildId);
            if (detail != null)
            {
                return detail.Quantity;
            }
            return null;
        }
    }
}
