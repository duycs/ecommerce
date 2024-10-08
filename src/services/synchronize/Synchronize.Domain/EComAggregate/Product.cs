using ECommerce.Shared.SeedWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Synchronize.Domain.EComAggregate
{
    [Table("products", Schema = "public")]
    public class Product : DateModiferTrackingEntity, IAggregateRoot
    {
        public Guid ShopId { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid? BrandId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string[] Images { get; private set; }
        public string Image { get; private set; }
        public bool IsSellFullSize { get; private set; }
        public virtual IList<ProductChild> Children { get; private set; }

        protected Product() { }

        public Product(Guid shopId, string sku, string name, string description, Guid? brandId, Guid categoryId, string[] images)
        {
            Id = Guid.NewGuid();
            ShopId = shopId;
            Sku = sku;
            Name = name;
            BrandId = brandId;
            CategoryId = categoryId;
            Images = images;
            Description = description;
            IsSellFullSize = false;
        }

        public void AddChild(ProductChild child)
        {
            Children ??= new List<ProductChild>();
            Children.Add(child);
        }

        public bool UpdateImages(string images)
        {
            Images ??= new string[] { };
            var deserializeImages = string.IsNullOrEmpty(images) ? new string[] { } : JsonConvert.DeserializeObject<SaasProductImages>(images).Urls;
            if (deserializeImages.Except(Images).Any())
            {
                Images = deserializeImages;
                Image = deserializeImages[0];
                return true;
            }
            return false;
        }
    }

    public class SaasProductImages
    {
        public int Count { get; set; }
        public string[] Urls { get; set; }
    }
}
