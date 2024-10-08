using ECommerce.Shared.SeedWork;

namespace ECommerce.Domain.Enums
{
    public class ProductType : Enumeration
    {
        public static ProductType New = new ProductType(1, "ProductNew");
        public static ProductType BestSelling = new ProductType(2, "BestSelling");
        public static ProductType Suggested = new ProductType(3, "Suggested");

        public ProductType() : base() { }
        public ProductType(int id, string name) : base(id, name)
        {
        }
    }
}
