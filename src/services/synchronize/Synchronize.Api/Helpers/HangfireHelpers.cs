using ECommerce.Shared.Constant;
using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.Common;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Synchronize.Api.Helpers
{
    public static class HangfireHelpers
    {
        public static IServiceCollection ConnectToHangfireStorage(this IServiceCollection services, IConfiguration configuration,
           Action<IServiceProvider, IGlobalConfiguration> extraAction = null)
        {
            var jobStorageConnectionString =
                configuration.GetConnectionString(ConnectionStrings.EComConnectionString);

            services.AddSingleton(_ => JobStorage.Current);
            services.AddSingleton(_ => (IJobFilterProvider)JobFilterProviders.Providers);
            services.AddSingleton(_ => (ITimeZoneResolver)new DefaultTimeZoneResolver());
            services.AddSingleton(sp =>
            {
                var globalConfig = GlobalConfiguration.Configuration;
                var queues = configuration.GetSection("Queues").Get<string[]>();
                var options = new BackgroundJobServerOptions()
                {
                    Queues = queues,
                    WorkerCount = configuration.GetValue<int>("HangfireWorkerCount", 1),
                };

                var loggerFactory = sp.GetService<ILoggerFactory>();
                globalConfig.UseLogProvider(new AspNetCoreLogProvider(loggerFactory));
                var timeOut = configuration.GetValue<int>("HangfireWorkerTimeout", 30);
                globalConfig.UsePostgreSqlStorage(jobStorageConnectionString, new PostgreSqlStorageOptions()
                {
                    PrepareSchemaIfNecessary = false,
                    SchemaName = "hangfire",
                    InvisibilityTimeout = TimeSpan.FromMinutes(timeOut),
                });

                globalConfig.UseFilter(new AutomaticRetryAttribute() { Attempts = 0 });
                extraAction?.Invoke(sp, globalConfig);
                return new BackgroundJobServer(options);
            });

            services.AddSingleton<IBackgroundJobClient>((x =>
                new BackgroundJobClient(x.GetRequiredService<JobStorage>(),
                    x.GetRequiredService<IJobFilterProvider>())));
            return services;
        }

        public static void RunHangFire(this IHost host)
        {
            host.Services.GetRequiredService<BackgroundJobServer>();
            host.Run();
        }
    }
}
