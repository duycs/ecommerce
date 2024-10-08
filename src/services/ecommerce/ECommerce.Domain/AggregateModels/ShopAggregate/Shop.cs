using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.AggregateModels.ShopAggregate
{
    public class Shop : DateModiferTrackingEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Address { get; private set; }
        public string CoverImage { get; private set; }
        public string Avatar { get; private set; }
        public string Description { get; private set; }
        public string ThumbImage { get; private set; }
        public string ImageList { get; private set; }
        public string MetaKeywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string SiteTitle { get; private set; }
        public string Video { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Content { get; private set; }
        public Guid WardId { get; private set; }

        public virtual IList<Product> ParentProducts { get; private set; }
        public virtual IList<ShopBankAccount> ShopBankAccounts { get; private set; }
        public virtual Ward Ward { get; private set; }

        protected Shop()
        {
        }

        public Shop(Guid id, string name, string address) : this()
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
