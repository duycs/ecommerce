using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;

namespace Integration.Domain.ECommerceAggregateModels
{
    public class Product : DateModiferTrackingEntity, IAggregateRoot
    {
        public string[] Images { get; private set; }
        public string Image { get; set; }

        protected Product() { }

        public void UpdateImages(string[] images)
        {
            Images = images;
            if (!Images.IsNullOrEmpty())
            {
                Image = images[0];
            }
            else
            {
                Image = string.Empty;
            }
        }
    }
}
