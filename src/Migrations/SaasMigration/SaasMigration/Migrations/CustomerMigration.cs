using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaasMigration.ECommerceModels;
using SaasMigration.ECommerceModels.Models;
using SaasMigration.IntegrationModels;
using SaasMigration.IntegrationModels.Models;
using SaasMigration.SaasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComModels = SaasMigration.ECommerceModels.Models;
using SasModels = SaasMigration.SaasModels.Models;

namespace SaasMigration.Migrations
{
    public class CustomerMigration : IMigrationTask
    {
        private readonly SaasDbContext _saasDbContext;
        private readonly EComDbContext _ecomDbContext;
        private readonly IntegrationDbContext _integrationDbContext;
        private readonly IServiceProvider _service;
        private static readonly string DEFAULT_PASSWORD = "Abc@123";

        public CustomerMigration(DbContextOptions<SaasDbContext> saasDbContext,
            DbContextOptions<EComDbContext> ecomDbContext,
            DbContextOptions<IntegrationDbContext> integrationDbContext,
            IServiceProvider service)
        {
            _saasDbContext = new SaasDbContext(saasDbContext);
            _ecomDbContext = new EComDbContext(ecomDbContext);
            _integrationDbContext = new IntegrationDbContext(integrationDbContext);
            _service = service;
        }

        public async Task RunAsync()
        {
            using (var scope = _service.CreateScope())
            {
                var _userManager = scope.ServiceProvider.GetService<UserManager<Account>>();
                var customers = await _saasDbContext.Customers.Where(a => a.IsDeleted == false && !string.IsNullOrEmpty(a.PhoneNumber)).ToListAsync();
                var ward = await _ecomDbContext.Wards.FirstOrDefaultAsync();
                foreach (var customer in customers)
                {
                    var newId = Guid.NewGuid();
                    var newCustomer = new EComModels.Customer();
                    newCustomer.Id = newId;
                    newCustomer.Name = customer.FullName;
                    newCustomer.PhoneNumber = customer.PhoneNumber;
                    newCustomer.Email = customer.Email;
                    newCustomer.Dob = customer.DateOfBirth == null ? null : Convert.ToDateTime(customer.DateOfBirth.Value);
                    newCustomer.Avatar = customer.Avatar;
                    newCustomer.Liabilities = customer.Liabilities ?? 0;
                    newCustomer.MaxLiabilities = customer.MaxLiabilities ?? 0;
                    newCustomer.CreatedDate = DateTime.UtcNow;
                    newCustomer.LastUpdatedDate = DateTime.UtcNow;
                    newCustomer.CreatedById = Guid.Empty;
                    newCustomer.LastUpdatedById = Guid.Empty;

                    if(!string.IsNullOrEmpty(customer.Address))
                    {
                        var address = new CustomerAddress();
                        address.Id = Guid.NewGuid();
                        address.Address = customer.Address;
                        address.ReceiverName = customer.FullName;
                        address.ReceiverPhoneNumber = customer.PhoneNumber;
                        address.CreatedDate = DateTime.UtcNow;
                        address.LastUpdatedDate = DateTime.UtcNow;
                        address.CreatedById = Guid.Empty;
                        address.LastUpdatedById = Guid.Empty;
                        address.IsDefault = true;

                        newCustomer.CustomerAddresses = new List<CustomerAddress>() { address };
                    }
                    _ecomDbContext.Customers.Add(newCustomer);

                    //var shop = new EComModels.Shop();
                    //shop.Id = newId;
                    //shop.Code = customer.Code ?? customer.PhoneNumber;
                    //shop.Name = customer.FullName;
                    //shop.Address = customer.Address;
                    //shop.PhoneNumber = customer.PhoneNumber;
                    //shop.Ward = ward;
                    //shop.CreatedDate = DateTime.UtcNow;
                    //shop.LastUpdatedDate = DateTime.UtcNow;
                    //shop.CreatedById = Guid.Empty;
                    //shop.LastUpdatedById = Guid.Empty;

                    //_ecomDbContext.Shops.Add(shop);

                    var newAccount = new Account();
                    newAccount.Id = newId;
                    newAccount.UserName = customer.PhoneNumber;
                    newAccount.PhoneNumber = customer.PhoneNumber;
                    newAccount.IsActive = true;
                    newAccount.CreatedById = Guid.Empty;
                    newAccount.LastUpdatedById = Guid.Empty;
                    newAccount.CreatedDate = DateTime.UtcNow;
                    newAccount.LastUpdatedDate = DateTime.UtcNow;
                    await _userManager.CreateAsync(newAccount, DEFAULT_PASSWORD);

                    // Add mappings
                    var mapping = new CustomerMapping();
                    mapping.CustomerId = newId;
                    mapping.OldId = customer.Id;
                    _integrationDbContext.CustomerMappings.Add(mapping);
                }

                await _ecomDbContext.SaveChangesAsync();
                await _integrationDbContext.SaveChangesAsync();
            }
        }
    }
}
