using ECommerce.Shared.SeedWork;

namespace Integration.Domain.ECommerceAggregateModels
{
    public class Customer : DateModiferTrackingEntity, IAggregateRoot
    {
        public decimal Liabilities { get; private set; }
        public decimal MaxLiabilities { get; private set; }

        protected Customer()
        {

        }

        public void UpdateLiabilities(decimal liabilities, decimal maxLiabilities)
        {
            Liabilities = liabilities;
            MaxLiabilities = maxLiabilities;
        }
    }
}
