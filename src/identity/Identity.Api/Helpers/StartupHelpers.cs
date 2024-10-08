using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Identity;
using ECommerce.Shared.Dotnet.Initialization;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Mvc;
using EventBus.Abstractions;
using Identity.Api.Initializations;
using Identity.Domain.AccountAggregate;
using Identity.Infrastructure;
using Identity.Services.IntegratedEventHandlers;
using Integration.Events;
using Integration.Events.CustomerEvents;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Shared = ECommerce.Shared.Configurations;

namespace Identity.Api.Helpers
{
    public static class StartupHelpers
    {
        public static readonly string AssemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceIdentityDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), b =>
                    {
                        b.MigrationsAssembly(AssemblyName);
                        b.MigrationsHistoryTable("__EFMigrationsHistory", ECommerceIdentityDbContext.SchemaName);
                    });
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
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IScopeContext, ScopeContext>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(serviceProvider =>
            {
                var actionContext = serviceProvider.GetService<IActionContextAccessor>()
                    .ActionContext;
                var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();

                return factory.GetUrlHelper(actionContext);
            });

            // Integration Event Handlers
            services.AddTransient<CustomerUpdatedEventHandler>();
            services.AddTransient<SaasCreatedAccountEventHandler>();
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Shared.AuthenticationSettings>(configuration.GetSection("ClientCredentials"));
            return services;
        }

        public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services, IConfiguration configuration, string assemblyName)
        {
            services.AddIdentity<Account, Role>()
                .AddEntityFrameworkStores<ECommerceIdentityDbContext>()
                .AddRoleStore<RoleStore<Role, ECommerceIdentityDbContext, Guid>>()
                .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(c => { c.ValidationInterval = TimeSpan.Zero; });

            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<Account>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddConfigurationStore(opts =>
                {
                    opts.ConfigureDbContext = co => co.UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), pg =>
                    {
                        pg.MigrationsAssembly(assemblyName);
                        pg.MigrationsHistoryTable("__EFMigrationsHistory", ECommerceIdentityDbContext.SchemaName);
                    });
                    opts.DefaultSchema = ECommerceIdentityDbContext.SchemaName;
                })
                .AddOperationalStore(opts =>
                {
                    opts.ConfigureDbContext = co => co.UseNpgsql(configuration.GetConnectionString(ConfigurationKeys.DefaultConnectionString), pg =>
                    {
                        pg.MigrationsAssembly(assemblyName);
                        pg.MigrationsHistoryTable("__EFMigrationsHistory", ECommerceIdentityDbContext.SchemaName);
                    });
                    opts.DefaultSchema = ECommerceIdentityDbContext.SchemaName;
                    opts.EnableTokenCleanup = true;
                    opts.TokenCleanupInterval = 3600;
                })
                .AddProfileService<ProfileService>()
                .AddJwtBearerClientAuthentication();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredUniqueChars = 0;
                opts.Password.RequiredLength = 6;
                opts.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                opts.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                opts.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
                opts.SignIn.RequireConfirmedEmail = false;
                opts.User.RequireUniqueEmail = false;
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

        public static IServiceCollection AddInitializations(this IServiceCollection services)
        {
            services.AddInitialization<DbMigrationStep>();
            services.AddInitialization<SeedIdentityStep>();
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

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<CustomerUpdatedIntegratedEvent, CustomerUpdatedEventHandler>();
            eventBus.Subscribe<SaasCreatedAccountIntegratedEvent, SaasCreatedAccountEventHandler>();
        }
    }
}
