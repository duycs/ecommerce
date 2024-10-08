using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.DomainEvents;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Domain.AggregateModels.CustomerAggregate
{
    public class Customer : DateModiferTrackingEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ExtraPhoneNumbers { get; private set; }
        public DateTime? DOB { get; private set; }
        public string Email { get; private set; }
        public int? Gender { get; private set; }
        public string Avatar { get; private set; }
        public decimal Liabilities { get; private set; }
        public decimal MaxLiabilities { get; private set; }

        public virtual IList<CustomerAddress> CustomerAddresses { get; set; }
        public virtual Cart Cart { get; private set; }

        protected Customer()
        {
        }

        public Customer(Guid id, string name, string phoneNumber) : this()
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            AddDomainEvent(new CustomerCreatedDomainEvent(this));
        }

        public void Update(string name)
        {
            Name = name;
        }

        #region Address
        public void AddAddress(CustomerAddress address)
        {
            CustomerAddresses ??= new List<CustomerAddress>();
            CustomerAddresses.Add(address);
            if (CustomerAddresses.Count == 1)
            {
                address.SetDefault();
            }
        }

        public CustomerAddress GetAddress(Guid id)
        {
            return CustomerAddresses?.FirstOrDefault(a => a.Id == id);
        }

        public CustomerAddress GetAddressDefault()
        {
            return CustomerAddresses?.FirstOrDefault(a => a.IsDefault == true);
        }

        public void DeleteAddress(Guid id)
        {
            var address = GetAddress(id);
            if (address != null)
            {
                CustomerAddresses.Remove(address);
                RandomDefault();
            }
        }

        public void RandomDefault()
        {
            if (CustomerAddresses.IsNullOrEmpty() || CustomerAddresses.Any(a => a.IsDefault))
            {
                return;
            }
            CustomerAddresses.First().SetDefault();
        }

        public void SetDefaultAddress(Guid id)
        {
            CustomerAddresses = CustomerAddresses.Select(a =>
            {
                if (a.Id == id)
                {
                    a.SetDefault();
                }
                else
                {
                    a.UnsetDefault();
                }
                return a;
            }).ToList();
        }
        #endregion
    }
}
