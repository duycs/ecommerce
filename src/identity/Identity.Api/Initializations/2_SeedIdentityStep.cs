using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Initialization;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Initializations
{
    public class SeedIdentityStep : IInitializationStep
    {
        public int Order => 2;
        private readonly IConfiguration _configuration;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly Dictionary<string, string[]> _secrets;

        public SeedIdentityStep(IConfiguration configuration, 
            ConfigurationDbContext configurationDbContext)
        {
            _configuration = configuration;
            _configurationDbContext = configurationDbContext;
            _secrets = configuration.GetSection(IdentityConfigurationKeys.Secrets).Get<Dictionary<string, string[]>>();
        }

        public async Task ExecuteAsync()
        {
            await SeedApiScopesAsync();
            await SeedIdentityResourcesAsync();
            await SeedApiResourcesAsync();
            await SeedClientsAsync();
        }

        public async Task SeedApiScopesAsync()
        {
            var currentScopes = await _configurationDbContext.ApiScopes.ToListAsync();
            var scopes = _configuration.GetSection(IdentityConfigurationKeys.ApiScopes).Get<IEnumerable<ApiScope>>();
            var newScopes = scopes.Where(t => currentScopes.All(s => s.Name != t.Name));
            foreach (var scope in newScopes)
            {
                await _configurationDbContext.ApiScopes.AddAsync(scope.ToEntity());
            }
            await _configurationDbContext.SaveChangesAsync();
        }

        public async Task SeedIdentityResourcesAsync()
        {
            var currentResourses = await _configurationDbContext.IdentityResources.ToListAsync();
            var resources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
            var newResources = resources.Where(t => currentResourses.All(r => r.Name != t.Name));
            foreach (var r in newResources)
            {
                await _configurationDbContext.IdentityResources.AddAsync(r.ToEntity());
            }
            await _configurationDbContext.SaveChangesAsync();
        }

        public async Task SeedApiResourcesAsync()
        {
            var currentResourses = await _configurationDbContext.ApiResources.ToListAsync();
            var resources = _configuration.GetSection(IdentityConfigurationKeys.ApiResources).Get<IList<ApiResource>>();
            var newResources = resources.Where(t => currentResourses.All(r => r.Name != t.Name));
            foreach (var r in newResources)
            {
                if (_secrets.TryGetValue(r.Name, out var secrets))
                {
                    r.ApiSecrets = secrets.Select(t => new Secret(t.Sha256())).ToList();
                }
                await _configurationDbContext.ApiResources.AddAsync(r.ToEntity());
            }
            await _configurationDbContext.SaveChangesAsync();
        }

        public async Task SeedClientsAsync()
        {
            var allClients = await _configurationDbContext.Clients.ToListAsync();
            var clients = _configuration.GetSection(IdentityConfigurationKeys.Clients).Get<IList<Client>>();
            var newClients = clients.Where(t => allClients.All(r => r.ClientId != t.ClientId));
            foreach (var client in newClients)
            {
                if (_secrets.TryGetValue(client.ClientId, out var secrets))
                {
                    client.ClientSecrets = secrets.Select(t => new Secret(t.Sha256())).ToList();
                }
                await _configurationDbContext.Clients.AddAsync(client.ToEntity());
            }
            await _configurationDbContext.SaveChangesAsync();
        }
    }
}
