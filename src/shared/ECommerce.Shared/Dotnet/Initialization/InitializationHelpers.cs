using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dotnet.Initialization
{
    public static class InitializationHelpers
    {
        public static IHost Initialize(this IHost host, bool always = false)
        {
            using IServiceScope serviceScope = host.Services.CreateScope();
            foreach (IInitializationStep item in from t in serviceScope.ServiceProvider.GetServices<IInitializationStep>()
                                                 orderby t.Order
                                                 select t)
            {
                item.ExecuteAsync().Wait();
            }

            return host;
        }

        public static IServiceCollection AddInitialization<T>(this IServiceCollection services) where T : class, IInitializationStep
        {
            services.AddScoped<IInitializationStep, T>();
            return services;
        }
    }
    public interface IInitializationStep
    {
        int Order { get; }

        Task ExecuteAsync();
    }
}
