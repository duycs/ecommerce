using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class ProductPrice
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductChildId { get; set; }
        public int QuantityFrom { get; set; }
        public int QuantityTo { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceDiscount { get; set; }
        public bool IsLimitQuantity { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductChild ProductChild { get; set; }
    }
}
