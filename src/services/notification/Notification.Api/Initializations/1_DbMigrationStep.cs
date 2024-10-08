using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.EntityFrameworkCore;
using Notification.Infrastructure;
using System.Threading.Tasks;

namespace Notification.Api.Initializations
{
    public class DbMigrationStep : IInitializationStep
    {
        public int Order => 1;
        private readonly NotificationDbContext _dbContext;

        public DbMigrationStep(NotificationDbContext dbContext)
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
