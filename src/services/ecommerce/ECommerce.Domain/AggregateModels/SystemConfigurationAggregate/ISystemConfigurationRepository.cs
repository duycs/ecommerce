using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.SystemConfigurationAggregate
{
    public interface ISystemConfigurationRepository
    {
        Task<SystemConfiguration> GetById(string id);
    }
}
