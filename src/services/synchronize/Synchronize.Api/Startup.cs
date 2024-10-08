using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;
using Synchronize.Api.Helpers;
using MediatR;
using EventBusRabbitMQ;
using ECommerce.Shared.Extensions;

namespace Synchronize.Api
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                 .AddCustomDbContext(Configuration)
                 .AddIoC(Configuration)
                 .AddConfigurations(Configuration)
                 .AddHangfireConfiguration(Configuration)
                 .ConnectToHangfireStorage(Configuration);

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddInitializations();
            services.ConfigureLocalization();
            services.AddUltimateMvc(Configuration);
            services.AddRazorPages();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddRabbitMQ(Configuration);
            DapperFluentMapper.AddDapperMapping();
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
            app.UseExceptionHandler("/Error");
            app.UseCors(opts =>
            {
                opts.AllowAnyHeader();
                opts.AllowAnyMethod();
                opts.AllowCredentials();
                opts.SetIsOriginAllowed(origin => true);
            });

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseHttpMethodOverride();
            app.UseHangfireDashboard("", new DashboardOptions()
            {
                Authorization = new[] { new HangFireAuthorizationFilter() {
                    
                } },
                IgnoreAntiforgeryToken = true,
                DashboardTitle = "ECommerce Hangfire",
            });
        }
    }
    
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
