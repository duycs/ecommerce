using Autofac.Extensions.DependencyInjection;
using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Synchronize.Api.Helpers;

namespace Synchronize.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Initialize().RunHangFire();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
