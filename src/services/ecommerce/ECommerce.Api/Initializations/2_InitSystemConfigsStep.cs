using ECommerce.Domain.AggregateModels.SystemConfigurationAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Api.Initializations
{
    public class InitSystemConfigsStep : IInitializationStep
    {
        public int Order => 2;
        private readonly ECommerceDbContext _dbContext;

        public InitSystemConfigsStep(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync()
        {
            await InitLocationVersion();
            await InitTransferContents();
            await InitTopProduct();
            await _dbContext.SaveChangesAsync();
        }

        private async Task InitLocationVersion()
        {
            if (await _dbContext.SystemConfigurations.CountAsync(a => a.Key == ConfigKeys.LocationVersion) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.LocationVersion, "1", ConfigKeys.LocationVersion, "Config version for location settings");
                _dbContext.SystemConfigurations.Add(config);
            }
        }

        private async Task InitTransferContents()
        {
            if (await _dbContext.SystemConfigurations.CountAsync(a => a.Key == ConfigKeys.SuggestTransferContents) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.SuggestTransferContents, "Số tiền và số điện thoại thanh toán", 
                                                        ConfigKeys.SuggestTransferContents, "Config suggest the content of the transfer");
                _dbContext.SystemConfigurations.Add(config);
            }
        }

        private async Task InitTopProduct()
        {
            if(await _dbContext.SystemConfigurations.CountAsync(s=>s.Key == ConfigKeys.TopNewProduct) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.TopNewProduct,
                                                    ConfigKeys.DefaultNumberTopProducts,
                                                    "Top new products home",
                                                    "Top new products at home screen");
                _dbContext.SystemConfigurations.Add(config);
            }

            if (await _dbContext.SystemConfigurations.CountAsync(s => s.Key == ConfigKeys.TopBestSellingProduct) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.TopBestSellingProduct,
                                                  ConfigKeys.DefaultNumberTopProducts,
                                                  "Top bestSelling products home",
                                                  "Top bestSelling products at home screen");
                _dbContext.SystemConfigurations.Add(config);
            }

            if (await _dbContext.SystemConfigurations.CountAsync(s => s.Key == ConfigKeys.TopSuggestedProduct) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.TopSuggestedProduct,
                                                  ConfigKeys.DefaultNumberTopProducts,
                                                  "Top suggested products home",
                                                  "Top suggested products at home screen");
                _dbContext.SystemConfigurations.Add(config);
            }

            if (await _dbContext.SystemConfigurations.CountAsync(s => s.Key == ConfigKeys.TopPurchaseProduct) == 0)
            {
                var config = new SystemConfiguration(ConfigKeys.TopPurchaseProduct,
                                                ConfigKeys.DefaultNumberTopProducts,
                                                "Top product purchase history",
                                                "Customer top product purchase history");
                _dbContext.SystemConfigurations.Add(config);
            }
        }
    }
}
