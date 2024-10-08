using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy("CorsPolicy", opts =>
                {
                    opts.AllowAnyHeader();
                    opts.AllowAnyMethod();
                    opts.AllowCredentials();
                    opts.SetIsOriginAllowed(origin => true);
                });
            });

            var identityUrl = Configuration.GetValue<string>("IdentityUrl");
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer("Bearer", x =>
                {
                    x.Authority = identityUrl;
                    x.RequireHttpsMetadata = false;
                });

            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseHttpMethodOverride();

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseWebSockets();

            // k8s ingress use this endpoint to determine whether service is ready or not
            app.Map("/health", b =>
            {
                b.Run(async x =>
                {
                    x.Response.StatusCode = StatusCodes.Status200OK;
                    await x.Response.WriteAsync("{}");
                });
            });
            app.UseOcelot().Wait();
        }
    }
}
