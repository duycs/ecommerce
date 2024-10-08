using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Order.Infrastructure;
using System.Data;
using System.Reflection;
using ECommerce.Shared.Helpers;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Shared = ECommerce.Shared.Configurations;
using Order.Api.Initializations;
using EventBus.Abstractions;
using Order.Domain.AggregateModels.OrderAggregate;
using Order.Infrastructure.Repositories;
using Integration.Events.CustomerEvents;
using Order.Services.IntegratedEventHandlers;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Mvc;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Dotnet.Initialization;
using ECommerce.Shared.Dotnet.Identity;

namespace Order.Api.Helpers
{
    public static class StartupHelpers
    {
        public static readonly string AssemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), b =>
                    {
                        b.MigrationsAssembly(AssemblyName);
                        b.MigrationsHistoryTable("__EFMigrationsHistory", OrderDbContext.SchemaName);
                    })
                    .UseSnakeCaseNamingConvention();
            })
            .AddScoped<IDbConnection>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var connection = new NpgsqlConnection(config.GetConnectionString(ConfigurationKeys.DefaultConnectionString));
                connection.Open();
                return connection;
            });

            return services;
        }

        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IScopeContext, ScopeContext>();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();

            // Repositories
            services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();

            // Eventbus
            services.AddTransient<CustomerOrderedEventHandler>();

            //Repository
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper().RegisterMap());
            return services;
        }

        public static IServiceCollection AddInitializations(this IServiceCollection services)
        {
            services.AddInitialization<DbMigrationStep>();
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .Configure<SaasConfiguration>(configuration.GetSection("SaasConfiguration"))
               .AddMemoryCache()
               .AddSingleton(sp =>
               {
                   var factory = sp.GetRequiredService<IHttpClientFactory>();
                   var config = sp.GetRequiredService<IOptionsSnapshot<SaasConfiguration>>();
                   var cache = sp.GetRequiredService<IMemoryCache>();
                   var logger = sp.GetRequiredService<ILogger<CustomHttpClient>>();
                   return new CustomHttpClient(factory, config, cache, logger);
               });
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    var settings = configuration.GetSection("Authentication").Get<Shared.AuthenticationSettings>();
                    options.Authority = settings.Authority;
                    options.RequireHttpsMetadata = settings.RequireHttpsMetadata;
                    options.ApiName = settings.ApiName;
                    options.ApiSecret = settings.ApiSecret;
                    options.TokenRetriever = CustomTokenRetriever.FromHeaderAndQueryString();
                });

            return services;
        }

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<CustomerOrderedIntegratedEvent, CustomerOrderedEventHandler>();
        }
    }
}
