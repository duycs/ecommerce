using AutoMapper;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Identity;
using ECommerce.Shared.Dotnet.Initialization;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers;
using ECommerce.Shared.Mvc;
using EventBus.Abstractions;
using Integration.Api.Initializations;
using Integration.Domain.AggregateModels;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Domain.OrderAggregateModels;
using Integration.Events.OrderEvents;
using Integration.Infrastructure;
using Integration.Infrastructure.Repositories;
using Integration.Infrastructure.Repositories.SystemLogAggregate;
using Integration.Services.IntegratedEventHandlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Reflection;

namespace Integration.Api.Helpers
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

            // Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderMappingRepository, OrderMappingRepository>();
            services.AddScoped<IProductChildRepository, ProductChildRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerMappingRepository, CustomerMappingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISystemLogRepository, SystemLogRepository>();

            // Eventbus
            services.AddTransient<OrderCreatedEventHandler>();
            services.AddTransient<OrderCancelledEventHandler>();
            services.AddTransient<OrderNoteUpdatedEventHandler>();
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
            eventBus.Subscribe<OrderCreatedIntegratedEvent, OrderCreatedEventHandler>();
            eventBus.Subscribe<OrderCancelledIntegratedEvent, OrderCancelledEventHandler>();
            eventBus.Subscribe<OrderNoteUpdatedIntegratedEvent, OrderNoteUpdatedEventHandler>();
        }
    }
}
