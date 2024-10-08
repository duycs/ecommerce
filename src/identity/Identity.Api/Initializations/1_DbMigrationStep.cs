
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.DbContexts;
using Identity.Infrastructure;
using ECommerce.Shared.Dotnet.Initialization;

namespace Identity.Api.Initializations
{
    public class DbMigrationStep : IInitializationStep
    {
        public int Order => 1;
        private readonly PersistedGrantDbContext _grantDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly ECommerceIdentityDbContext _dbContext;

        public DbMigrationStep(PersistedGrantDbContext grantDbContext, ConfigurationDbContext configurationDbContext, ECommerceIdentityDbContext dbContext)
        {
            _grantDbContext = grantDbContext;
            _configurationDbContext = configurationDbContext;
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync()
        {
            await _grantDbContext.Database.MigrateAsync();
            await _grantDbContext.SaveChangesAsync();
            await _configurationDbContext.Database.MigrateAsync();
            await _configurationDbContext.SaveChangesAsync();
            await _dbContext.Database.MigrateAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
