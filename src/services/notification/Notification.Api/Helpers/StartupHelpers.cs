using AutoMapper;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Identity;
using ECommerce.Shared.Dotnet.Initialization;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers;
using ECommerce.Shared.Mvc;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Api.Initializations;
using Notification.Domain.AggregateModels.NotificationAggregate;
using Notification.Domain.AggregateModels.TemplateAggregate;
using Notification.Infrastructure;
using Notification.Infrastructure.Repositories;
using Notification.Services.IntegratedEventHandlers;
using Notification.Services.ServiceInterfaces;
using Notification.Services.Services;
using Npgsql;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace Notification.Api.Helpers
{
    public static class StartupHelpers
    {
        public static readonly string AssemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotificationDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), b =>
                    {
                        b.MigrationsAssembly(AssemblyName);
                        b.MigrationsHistoryTable("__EFMigrationsHistory", NotificationDbContext.SchemaName);
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
            services.AddScoped<INotificationUnitOfWork, NotificationUnitOfWork>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddScoped<INotificationHistoryRepository, NotificationHistoryRepository>();
            services.AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>();
            // Add Event Handlers
            services.AddTransient<OrderStatusChangedEventHandler>();
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
            services.AddInitialization<InitNotificationTemplatesStep>();
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OneSignalConfiguration>(configuration.GetSection("OneSignal"));
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
            eventBus.Subscribe<OrderStatusChangedIntegratedEvent, OrderStatusChangedEventHandler>();
        }
    }
}
