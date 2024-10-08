using ECommerce.Domain.AggregateModels.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Shared.Models;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Domain.AggregateModels.CartAggregate
{
    public class Cart : DateModiferTrackingEntity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public string Note { get; private set; }

        public virtual IList<CartDetail> CartDetails { get; private set; }
        public virtual Customer Customer { get; private set; }

        protected Cart()
        {
            CartDetails = new List<CartDetail>();
        }

        public void Order()
        {
            foreach (var detail in CartDetails)
            {
                detail.Order();
            }
            CartDetails = new List<CartDetail>();
        }

        public Cart(Guid customerId)
        {
            CustomerId = customerId;
            CartDetails = new List<CartDetail>();
        }

        //public void AddOrUpdateDetails(List<Item> items)
        //{
        //    CartDetails ??= new List<CartDetail>();
        //    foreach (var item in items)
        //    {
        //        var detail = CartDetails?.FirstOrDefault(f => f.ProductChildId == item.Id);

        //        if (detail == null)
        //            CartDetails.Add(new CartDetail(Id, item.Id, item.Quantity));
        //        else
        //            detail.UpdateAddQuantity(item.Quantity);
        //    }
        //}

        public void AddOrUpdateDetail(ProductChild child, uint quantity)
        {
            CartDetails ??= new List<CartDetail>();
            var detail = CartDetails.FirstOrDefault(a => a.ProductChildId == child.Id);
            if (detail == null)
            {
                detail = new CartDetail(Id, child, quantity);
                CartDetails.Add(detail);
            }
            else
            {
                detail.UpdateAddQuantity(quantity);
            }
        }

        public void UpdateQuantityDetails(List<Item> items)
        {
            foreach (var item in items)
            {
                var detail = CartDetails.FirstOrDefault(w => w.ProductChildId == item.Id);
                if (detail == null) continue;
                detail.UpdateQuantity(item.Quantity);
            }
        }

        public void RemoveDetails(IList<Guid> items)
        {
            CartDetails = CartDetails.Where(a => !items.Contains(a.ProductChildId)).ToList();
        }
    }
}
