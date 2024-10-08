using System.Threading.Tasks;
using ECommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.Dotnet.Initialization;

namespace ECommerce.Api.Initializations
{
    public class DbMigrationStep : IInitializationStep
    {
        public int Order => 1;
        private readonly ECommerceDbContext _dbContext;

        public DbMigrationStep(ECommerceDbContext dbContext)
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
