using ECommerce.Shared.Dotnet.Initialization;
using Integration.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Integration.Api.Initializations
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
