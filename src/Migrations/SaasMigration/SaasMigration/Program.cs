using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaasMigration.ECommerceModels;
using SaasMigration.ECommerceModels.Models;
using SaasMigration.IntegrationModels;
using SaasMigration.Migrations;
using SaasMigration.SaasModels;
using System;
using System.Numerics;
using System.Text;

namespace SaasMigration
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        internal static void Main(string[] args)
        {
            RegisterServices();

            var application = _serviceProvider.GetRequiredService<ConsoleApplication>();
            application.RunAsync().GetAwaiter().GetResult();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            // FOR SAAS
            var saasOptionsBuilder = new DbContextOptionsBuilder<SaasDbContext>();
            saasOptionsBuilder
                .UseMySql(configuration.GetConnectionString("SaasConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("SaasConnection")))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            services.AddSingleton(saasOptionsBuilder.Options);

            // FOR ECOM
            var ecomOptionsBuilder = new DbContextOptionsBuilder<EComDbContext>();
            ecomOptionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("EComConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            services.AddSingleton(ecomOptionsBuilder.Options);

            var integrationOptionBuilder = new DbContextOptionsBuilder<IntegrationDbContext>();
            integrationOptionBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("EComConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            services.AddSingleton(integrationOptionBuilder.Options);

            // FOR IDENTITY
            services.AddDbContext<EComIdentityDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EComConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            services.AddIdentity<Account, Role>()
                .AddEntityFrameworkStores<EComIdentityDbContext>();

            services
                .AddLogging(conf => { conf.AddConsole(); })
                .AddSingleton<ProductMigration>()
                .AddSingleton<CustomerMigration>()
                .AddSingleton<Executioner>()
                .Configure<LoggerFilterOptions>(opt => { opt.MinLevel = LogLevel.Information; })
                .AddSingleton<ConsoleApplication>();

            _serviceProvider = services.BuildServiceProvider(true);
            Console.OutputEncoding = Encoding.Unicode;
        }

        private static void DisposeServices()
        {
            switch (_serviceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}
