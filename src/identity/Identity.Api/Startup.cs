using ECommerce.Shared.Extensions;
using EventBusRabbitMQ;
using Identity.Api.Helpers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace Identity.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services
               .AddRouting(options => options.LowercaseUrls = true)
               .AddCustomDbContext(_configuration)
               .AddIoC(_configuration)
               .AddConfigurations(_configuration)
               .AddCustomAuthentication(_configuration)
               .AddIdentityConfigurations(_configuration, assemblyName);

            services.AddInitializations();
            services.AddMapper(_configuration);
            services.ConfigureLocalization();
            services.AddUltimateMvc(_configuration);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddMediatR(typeof(Identity.Application.Read.Assembly).GetTypeInfo().Assembly)
                .AddMediatR(typeof(Identity.Application.Write.Assembly).GetTypeInfo().Assembly);
            services.AddRazorPages();
            DapperFluentMapper.AddDapperMapping();

            services.AddRabbitMQ(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };
            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();
            app.UseForwardedHeaders(forwardOptions);
            app.UseExceptionHandler("/error");
            app.UseCors(opts =>
            {
                opts.AllowAnyHeader();
                opts.AllowAnyMethod();
                opts.AllowCredentials();
                opts.SetIsOriginAllowed(origin => true);
            });

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.ConfigureEventBus();
        }
    }
}
