using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using System.Threading.Tasks;

namespace Order.Api.Initializations
{
    public class DbMigrationStep : IInitializationStep
    {
        public int Order => 1;
        private readonly OrderDbContext _dbContext;

        public DbMigrationStep(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync()
        {
            await _dbContext.Database.MigrateAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
