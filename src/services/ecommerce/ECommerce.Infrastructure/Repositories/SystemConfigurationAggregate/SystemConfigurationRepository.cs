using ECommerce.Domain.AggregateModels.SystemConfigurationAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.SystemConfigurationAggregate
{
    public class SystemConfigurationRepository : ISystemConfigurationRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<SystemConfiguration> _dbSet;

        public SystemConfigurationRepository(ECommerceDbContext context)
        {
            _context = (context ?? throw new ArgumentException("dbContext"));
        }

        public async Task<SystemConfiguration> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
