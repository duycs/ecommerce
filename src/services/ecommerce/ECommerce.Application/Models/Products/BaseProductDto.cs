using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Products
{    public abstract class BaseProductDto 
    {
        public Guid Id { get; set; }
        public Guid ShopId {get; set;}
        public string Sku {get; set;}
        public string Name {get; set;}
        public Guid? BrandId {get; set;}
        public string BrandName { get; set; }
        public Guid CategoryId {get; set;}
        public string CategoryName { get; set; }
        public string Description {get; set;}
        public string Image {get; set;}
        public string ThumbIamge {get; set;}
        public string[] Images {get; set;}
        public bool IsSellFullSize {get; set;}
    }
}
