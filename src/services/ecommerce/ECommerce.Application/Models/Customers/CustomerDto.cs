using ECommerce.Shared.SeedWork;

namespace ECommerce.Application.Models.Customers
{
    public class CustomerDto : DateModiferTrackingEntityDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
