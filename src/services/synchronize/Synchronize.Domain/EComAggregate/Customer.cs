using ECommerce.Shared.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synchronize.Domain.EComAggregate
{
    [Table("customers", Schema = "public")]
    public class Customer : DateModiferTrackingEntity
    {
        public decimal Liabilities { get; private set; }
        public decimal MaxLiabilities { get; private set; }

        protected Customer() { }

        public bool UpdateLiabilities(decimal liabilities, decimal maxLiablities)
        {
            if (Liabilities != liabilities || MaxLiabilities != maxLiablities)
            {
                Liabilities = liabilities;
                MaxLiabilities = maxLiablities;
                return true;
            }
            return false;
        }
    }
}
