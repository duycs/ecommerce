using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synchronize.Domain.SaasAggregate
{
    public class Product
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public int? AttributeFixedId { get; set; }
        public int? AttributeInputId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal? PriceWholesale { get; set; }
        public string Images { get; set; }

        public ImageJsonData JsonImages => string.IsNullOrEmpty(Images) ? null : JsonConvert.DeserializeObject<ImageJsonData>(Images);
    }

    public class ImageJsonData
    {
        public int Count { get; set; }
        public string[] Urls { get; set; }
    }
}
