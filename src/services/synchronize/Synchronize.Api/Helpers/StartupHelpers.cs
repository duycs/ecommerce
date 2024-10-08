using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Synchronize.Infrastructure;
using Hangfire;
using Hangfire.PostgreSql;
using Npgsql;
using ECommerce.Shared.Constant;
using MySql.Data.MySqlClient;
using Synchronize.Api.Initializations;
using Scheduler.Jobs.CronJobs.SyncJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ECommerce.Shared.Helpers;
using Synchronize.BackgroundTasks.SyncJobs;
using Synchronize.BackgroundTasks.Helpers;
using ECommerce.Shared.Mvc;
using ECommerce.Shared.Dotnet.Initialization;

namespace Synchronize.Api.Helpers
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            // ECom DbContext
            services.AddDbContext<ECommerceDbContext>(options =>
                {
                    options.UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString(ConnectionStrings.EComConnectionString))
                        .UseSnakeCaseNamingConvention();
                })
                .AddScoped<IEComDbConnection>(sp =>
                {
                    var connection = new EComDbConnection(new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString(ConnectionStrings.EComConnectionString)));
                    connection.Open();
                    return connection;
                })
                .AddScoped<ISaasDbConnection>(sp =>
                {
                    var connection = new SaasDbConnection(new MySqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString(ConnectionStrings.SaasConnectionString)));
                    connection.Open();
                    return connection;
                });

            return services;
        }

        public static IServiceCollection AddInitializations(this IServiceCollection services)
        {
            services.AddInitialization<AddCronJobsStep>();
            return services;
        }

        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IScopeContext, ScopeContext>();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddScoped<ISynchronizeUnitOfWork, SynchronizeUnitOfWork>();

            // Jobs
            services.AddTransient<ISyncCustomerLiabilitiesJob, SyncCustomerLiabilitiesJob>();
            services.AddTransient<ISyncQuantityInStockJob, SyncQuantityInStockJob>();
            services.AddTransient<ISyncPriceJob, SyncPriceJob>();
            services.AddTransient<ISyncDeletedProductJob, SyncDeletedProductJob>();
            services.AddTransient<ISyncAddedProductJob, SyncAddedProductJob>();
            services.AddTransient<ISyncProductImagesJob, SyncProductImagesJob>();
            services.AddTransient<ISyncOrderStatusJob, SyncOrderStatusJob>();
            services.AddTransient<ISyncOrderStaffJob, SyncOrderStaffJob>();
            services.AddTransient<ISyncOrderDetailsJob, SyncOrderDetailsJob>();
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SynchronizeConfigurations>(configuration.GetSection("SynchronizeConfigurations"));
            return services;
        }

        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStrings.EComConnectionString);
            services.AddHangfire((sp, config) =>
            {
                config.UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions()
                {
                    SchemaName = "hangfire"
                });
            });
            return services;
        }
    }
}