using AutoMapper;
using ECommerce.Api.Initializations;
using ECommerce.Application.Read.QueryHandlers;
using ECommerce.Application.ServiceInterfaces.HandlerInterface;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.ShopAggregate;
using ECommerce.Domain.AggregateModels.SystemConfigurationAggregate;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Repositories.CartAggregate;
using ECommerce.Infrastructure.Repositories.CustomerAggregate;
using ECommerce.Infrastructure.Repositories.ProductAggregate;
using ECommerce.Infrastructure.Repositories.ShopAggregate;
using ECommerce.Infrastructure.Repositories.SystemConfigurationAggregate;
using ECommerce.Services.IntegratedEventHandlers;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Identity;
using ECommerce.Shared.Dotnet.Initialization;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers;
using ECommerce.Shared.Mvc;
using EventBus.Abstractions;
using Integration.Events.CustomerEvents;
using Integration.Events.OrderEvents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace ECommerce.Api.Helpers
{
    public static class StartupHelpers
    {
        public static readonly string AssemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), b =>
                    {
                        b.MigrationsAssembly(AssemblyName);
                        b.MigrationsHistoryTable("__EFMigrationsHistory", ECommerceDbContext.SchemaName);
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
            services.AddScoped<IECommerceUnitOfWork, ECommerceUnitOfWork>();

            //Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ISystemConfigurationRepository, SystemConfigurationRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Add Utility
            services.AddTransient<IProductUtilities, ProductUtilities>();

            // Add Event Handlers
            services.AddTransient<AccountCreatedEventHandler>();
            services.AddTransient<OrderCancelledEventHandler>();
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
            services.AddInitialization<InitSystemConfigsStep>();
            services.AddInitialization<InitFunctionDbStep>();

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
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
                    var settings = configuration.GetSection("Authentication").Get<AuthenticationSettings>();
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
            eventBus.Subscribe<AccountCreatedIntegratedEvent, AccountCreatedEventHandler>();
            eventBus.Subscribe<OrderCancelledIntegratedEvent, OrderCancelledEventHandler>();
        }
    }
}
