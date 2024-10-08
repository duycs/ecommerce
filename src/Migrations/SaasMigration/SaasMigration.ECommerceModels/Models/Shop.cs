using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Products = new HashSet<Product>();
            ShopBankAccounts = new HashSet<ShopBankAccount>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string CoverImage { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string ThumbImage { get; set; }
        public string ImageList { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string SiteTitle { get; set; }
        public string Video { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public Guid WardId { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual Ward Ward { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ShopBankAccount> ShopBankAccounts { get; set; }
    }
}
