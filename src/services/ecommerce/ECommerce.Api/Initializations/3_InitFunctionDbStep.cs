using ECommerce.Infrastructure;
using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Api.Initializations
{
    public class InitFunctionDbStep : IInitializationStep
    {
        public int Order => 3;

        private readonly ECommerceDbContext _dbContext;

        public InitFunctionDbStep(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync()
        {
            await CreateExtensionUnaccent();
            await _dbContext.SaveChangesAsync();
        }

        private async Task CreateExtensionUnaccent()
        {
            _dbContext.Database.ExecuteSqlRaw(@"CREATE EXTENSION  IF NOT EXISTS unaccent;");
        }
    }
}
